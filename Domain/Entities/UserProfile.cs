using Enums;

namespace Domain.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ProfileType? ProfileType { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public SmartCode GenderIdentity { get; set; }
        public SmartCode SexualIdentity { get; set; }
        public SmartCode PrimaryLanguage { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
        public ICollection<UserOrganization> Organizations { get; set; } = new List<UserOrganization>();
        public ICollection<MultiSelection> MultiSelections { get; set; } = new List<MultiSelection>();
        public ICollection<EducationHistory> EducationHistories { get; set; } = new List<EducationHistory>();
        public ICollection<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<WorkHistory> WorkHistories { get; set; } = new List<WorkHistory>();
        public ICollection<UserBlock> Blocks { get; set; } = new List<UserBlock>();
        public ICollection<SchoolClaim> SchoolClaims { get; set; } = new List<SchoolClaim>();
        public ICollection<CompanyClaim> CompanyClaims { get; set; } = new List<CompanyClaim>();
        public ICollection<UserConnection> ApprovedConnections { get; set; } = new List<UserConnection>();
        public ICollection<UserConnection> InitiatedConnections { get; set; } = new List<UserConnection>();
        public ICollection<WorkSample> WorkSamples { get; set; } = new List<WorkSample>();
    }
}
