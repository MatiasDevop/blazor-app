using System;

namespace ViewModels.Dtos
{
    public class BaseOrganizationDocumentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public AttachmentDto File { get; set; }
        public string Url { get; set; }
    }
}