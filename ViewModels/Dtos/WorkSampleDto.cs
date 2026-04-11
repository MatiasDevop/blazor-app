using System;
using System.ComponentModel.DataAnnotations;
using Enums;

namespace ViewModels.Dtos
{
    public class WorkSampleDto : ICloneable
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkSampleType Type { get; set; }
        public AttachmentDto File { get; set; }
        public string Url { get; set; }
        public object Clone() => MemberwiseClone();
    }
}