using System;
using Enums;
using ViewModels.Dtos;

namespace ViewModels.ViewModels
{
    public class UserLabelVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public WorkHistoryDto LatestJob { get; set; }
        public ProfileType ProfileType { get; set; }
    }
}