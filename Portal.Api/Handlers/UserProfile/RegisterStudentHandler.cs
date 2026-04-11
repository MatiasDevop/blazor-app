using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.UserProfile;
using Enums;

namespace Portal.Api.Handlers.UserProfile;

public class RegisterStudentHandler : IRequestHandler<RegisterStudentRequest, RegisterStudentResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RegisterStudentHandler> _logger;

    public RegisterStudentHandler(ApplicationDbContext context, ILogger<RegisterStudentHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<RegisterStudentResult> Handle(RegisterStudentRequest request, CancellationToken cancellationToken)
    {
        var command = request.Command;

        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            // Validate email uniqueness
            var emailExists = await _context.UserProfiles
                .AnyAsync(u => u.Email == command.EmailAddress, cancellationToken);

            if (emailExists)
            {
                _logger.LogWarning("Registration failed: Email {Email} already exists", command.EmailAddress);
                return new RegisterStudentResult(
                    request.RequestId,
                    Guid.Empty,
                    command.EmailAddress,
                    false,
                    "Email address is already registered");
            }

            // Create UserProfile
            var userProfile = new Domain.Entities.UserProfile
            {
                Id = Guid.NewGuid(),
                Email = command.EmailAddress,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Phone = command.Phone,
                PhoneNumber = command.Phone,
                ProfileType = ProfileType.Student,
                CreatedAt = DateTime.UtcNow
            };

            // Set SmartCode references (Gender, Language, etc.)
            if (command.GenderIdentity != Guid.Empty)
            {
                var genderIdentity = await _context.SmartCodes.FindAsync(new object[] { command.GenderIdentity }, cancellationToken);
                if (genderIdentity != null)
                    userProfile.GenderIdentity = genderIdentity;
            }

            if (command.SexualIdentity != Guid.Empty)
            {
                var sexualIdentity = await _context.SmartCodes.FindAsync(new object[] { command.SexualIdentity }, cancellationToken);
                if (sexualIdentity != null)
                    userProfile.SexualIdentity = sexualIdentity;
            }

            if (command.PrimaryLanguage?.Id != Guid.Empty)
            {
                var primaryLanguage = await _context.SmartCodes.FindAsync(new object[] { command.PrimaryLanguage.Id }, cancellationToken);
                if (primaryLanguage != null)
                    userProfile.PrimaryLanguage = primaryLanguage;
            }

            _context.UserProfiles.Add(userProfile);

            // Create Address
            if (command.MailingAddress != null)
            {
                var address = new Address
                {
                    Id = Guid.NewGuid(),
                    Line1 = command.MailingAddress.Line1,
                    City = command.MailingAddress.City,
                    ZipCode = command.MailingAddress.ZipCode,
                    PostalCode = command.MailingAddress.ZipCode
                };

                if (command.MailingAddress.State != Guid.Empty)
                {
                    var state = await _context.SmartCodes.FindAsync(new object[] { command.MailingAddress.State }, cancellationToken);
                    if (state != null)
                        address.State = state;
                }

                _context.Addresses.Add(address);
                userProfile.Addresses.Add(address);
            }

            // Create Work Histories
            if (command.WorkHistories != null && command.WorkHistories.Any())
            {
                foreach (var workDto in command.WorkHistories)
                {
                    var workHistory = new WorkHistory
                    {
                        Id = Guid.NewGuid(),
                        UserProfileId = userProfile.Id,
                        JobTitle = workDto.JobTitle,
                        CompanyName = workDto.Company?.Name,
                        StartDate = workDto.StartDate,
                        EndDate = workDto.EndDate,
                        Description = workDto.JobDescription
                    };

                    _context.WorkHistories.Add(workHistory);
                }
            }

            // Create Education Histories
            if (command.EducationHistories != null && command.EducationHistories.Any())
            {
                foreach (var eduDto in command.EducationHistories)
                {
                    var educationHistory = new EducationHistory
                    {
                        Id = Guid.NewGuid(),
                        UserProfileId = userProfile.Id,
                        SchoolName = eduDto.School?.UniversityName ?? eduDto.School?.CollegeName,
                        GraduationDate = eduDto.GraduationDate,
                        GradePointAverage = eduDto.GradePointAverage ?? 0
                    };

                    _context.EducationHistories.Add(educationHistory);

                    // Note: EducationFocus is linked to School, not EducationHistory
                    // Majors and Minors would be stored differently in this schema
                    // Skipping for now as the entity relationships don't match the DTO structure
                }
            }

            // Create Social Links
            if (command.SocialLinks != null && command.SocialLinks.Any())
            {
                foreach (var linkDto in command.SocialLinks)
                {
                    var socialLink = new SocialLink
                    {
                        Id = Guid.NewGuid(),
                        Url = linkDto.Url,
                        UserProfileId = userProfile.Id
                    };
                    _context.SocialLinks.Add(socialLink);
                }
            }

            // Create Work Samples
            if (command.WorkSamples != null && command.WorkSamples.Any())
            {
                foreach (var sampleDto in command.WorkSamples)
                {
                    var workSample = new WorkSample
                    {
                        Id = Guid.NewGuid(),
                        Title = sampleDto.Title,
                        Description = sampleDto.Description,
                        Url = sampleDto.Url,
                        UserProfileId = userProfile.Id
                    };
                    _context.WorkSamples.Add(workSample);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            _logger.LogInformation("Student user profile created successfully: {UserId}, Email: {Email}",
                userProfile.Id, userProfile.Email);

            return new RegisterStudentResult(
                request.RequestId,
                userProfile.Id,
                userProfile.Email,
                true,
                "Student registered successfully");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(ex, "Error registering student with email {Email}", command.EmailAddress);
            throw;
        }
    }
}
