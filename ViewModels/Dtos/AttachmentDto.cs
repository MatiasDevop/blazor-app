using System.ComponentModel.DataAnnotations;

namespace ViewModels.Dtos
{
    public class AttachmentDto
    {
        [Required]
        public string FileName { get; set; }
        public string FileContent { get; set; }
    }
}