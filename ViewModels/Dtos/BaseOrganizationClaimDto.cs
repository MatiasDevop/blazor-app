using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Constants;

namespace ViewModels.Dtos
{
    public abstract class BaseOrganizationClaimDto
    {
        public Guid PartnerPlan { get; set; }
        public DiscountDto Discount { get; set; }
        public AttachmentDto Logo { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        [RegularExpression(Validators.EmailPattern, ErrorMessage = ValidatorMessages.EmailMessage)]
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public string Description { get; set; }
        public Guid OrganizationSize { get; set; }
        public List<SocialLinkDto> SocialLinks { get; set; }
        public string VideoUrl { get; set; }
        public Guid Id { get; set; }
    }
}