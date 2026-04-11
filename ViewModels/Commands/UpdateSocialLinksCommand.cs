using System.Collections.Generic;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class UpdateSocialLinksCommand
    {
        public List<SocialLinkDto> SocialLinks { get; set; } = new();
    }
}