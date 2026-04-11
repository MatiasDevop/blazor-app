using System.Collections.Generic;
using ViewModels.Dtos;

namespace ViewModels.ViewModels
{
    public class TransitioningUserVm : UserProfileDto
    {
        public List<SchoolDto> Schools { get; set; } = new();
        public List<CompanyProfileDto> Companies { get; set; } = new();
    }
}