using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Constants;
using Enums;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class RegisterStudentCommand : RegisterIndividualCommand
    {
        public AttachmentDto Resume { get; set; }
        public List<WorkSampleDto> WorkSamples { get; set; } = new();
        public List<SocialLinkDto> SocialLinks { get; set; } = new();
        public WorkAuthorizationType WorkAuthorizationType { get; set; }
        public string WorkAuthorizationOther { get; set; }
    }
}