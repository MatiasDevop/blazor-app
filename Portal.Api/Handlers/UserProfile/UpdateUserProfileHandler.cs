using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Domain.Entities;
using ViewModels.Requests.Endpoints.UserProfile;

namespace Portal.Api.Handlers.UserProfile;

public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileRequest, UpdateUserProfileResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UpdateUserProfileHandler> _logger;

    public UpdateUserProfileHandler(ApplicationDbContext context, ILogger<UpdateUserProfileHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<UpdateUserProfileResult> Handle(UpdateUserProfileRequest request, CancellationToken cancellationToken)
    {
        var command = request.Command;

        var userProfile = await _context.UserProfiles
            .Include(u => u.Addresses)
            .Include(u => u.GenderIdentity)
            .Include(u => u.SexualIdentity)
            .Include(u => u.PrimaryLanguage)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (userProfile == null)
        {
            _logger.LogWarning("User profile {UserId} not found for update", request.UserId);
            throw new KeyNotFoundException($"User profile with ID {request.UserId} not found");
        }

        // Update scalar properties
        userProfile.FirstName = command.FirstName;
        userProfile.LastName = command.LastName;
        userProfile.Phone = command.Phone;
        userProfile.PhoneNumber = command.Phone;
        userProfile.UpdatedAt = DateTime.UtcNow;

        // Update SmartCode references
        if (command.GenderIdentity != Guid.Empty)
        {
            var genderIdentity = await _context.SmartCodes.FindAsync(
                new object[] { command.GenderIdentity }, cancellationToken);
            if (genderIdentity != null)
                userProfile.GenderIdentity = genderIdentity;
        }

        if (command.SexualIdentity != Guid.Empty)
        {
            var sexualIdentity = await _context.SmartCodes.FindAsync(
                new object[] { command.SexualIdentity }, cancellationToken);
            if (sexualIdentity != null)
                userProfile.SexualIdentity = sexualIdentity;
        }

        if (command.PrimaryLanguage != Guid.Empty)
        {
            var primaryLanguage = await _context.SmartCodes.FindAsync(
                new object[] { command.PrimaryLanguage }, cancellationToken);
            if (primaryLanguage != null)
                userProfile.PrimaryLanguage = primaryLanguage;
        }

        // Update address
        if (command.MailingAddress != null)
        {
            var existingAddress = userProfile.Addresses.FirstOrDefault();
            if (existingAddress != null)
            {
                // Update existing address
                existingAddress.Line1 = command.MailingAddress.Line1;
                existingAddress.City = command.MailingAddress.City;
                existingAddress.ZipCode = command.MailingAddress.ZipCode;
                existingAddress.PostalCode = command.MailingAddress.ZipCode;

                if (command.MailingAddress.State != Guid.Empty)
                {
                    var state = await _context.SmartCodes.FindAsync(
                        new object[] { command.MailingAddress.State }, cancellationToken);
                    if (state != null)
                        existingAddress.State = state;
                }
            }
            else
            {
                // Create new address
                var newAddress = new Address
                {
                    Id = Guid.NewGuid(),
                    Line1 = command.MailingAddress.Line1,
                    City = command.MailingAddress.City,
                    ZipCode = command.MailingAddress.ZipCode,
                    PostalCode = command.MailingAddress.ZipCode
                };

                if (command.MailingAddress.State != Guid.Empty)
                {
                    var state = await _context.SmartCodes.FindAsync(
                        new object[] { command.MailingAddress.State }, cancellationToken);
                    if (state != null)
                        newAddress.State = state;
                }

                _context.Addresses.Add(newAddress);
                userProfile.Addresses.Add(newAddress);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("User profile {UserId} updated successfully", request.UserId);

        return new UpdateUserProfileResult(
            request.RequestId,
            true,
            "User profile updated successfully");
    }
}
