using System;

namespace ViewModels.Dtos
{
    public class SocialLinkDto
    {
        public Guid Id { get; set; }
        public Guid Type { get; set; }
        public string Url { get; set; }
    }
}