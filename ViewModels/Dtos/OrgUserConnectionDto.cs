using System;
using ViewModels.ViewModels;

namespace ViewModels.Dtos
{
    public class OrgUserConnectionDto
    {
        public Guid Id { get; set; }
        public Guid? SchoolId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid UserId { get; set; }
        public bool IsUserManager { get; set; }
        public bool IsJobsManager { get; set; }
        public bool IsEventsManager { get; set; }
        public bool IsAccounting { get; set; }
        public bool IsBilling { get; set; }
        public bool IsTechnicalContact { get; set; }
        public bool DisplayProfile { get; set; }
        public bool IsRecruiterOrContact { get; set; }
        public bool IsAffinityGroupLeader { get; set; }
    }
}