using Enums;

namespace Domain.Entities
{
    public class JobPost
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;

        public string JobTitle { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? JobLocation { get; set; }
        public decimal? MinCompensation { get; set; }
        public decimal? MaxCompensation { get; set; }
        public bool IsActive { get; set; } = true;
        public string CompensationDetails { get; set; }
        public string SalaryOffered { get; set; }
        public bool UseCpccApplyNow { get; set; }
        public string ApplyUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime ExpirationDate { get; set; }
        public UserProfile AssignedRecruiter { get; set; }
        public JobType Type { get; set; }
        public CompanyClaim Company { get; set; }
        public ICollection<ApplicationQuestion> Questions { get; set; }
        public ICollection<JobRequirementGroup> RequirementGroups { get; set; }
        public ICollection<JobBenefit> Benefits { get; set; }
        public ICollection<JobRequirement> Requirements { get; set; } = new List<JobRequirement>();
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
