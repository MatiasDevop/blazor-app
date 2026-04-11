using ViewModels.Dtos;

namespace ViewModels.ViewModels
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public AttachmentDto ProfileImage { get; set; }
        public string JobTitle { get; set; }
    }
}