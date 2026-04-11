using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class CreateNewSchoolCommand
    {
        public string UniversityName { get; set; }
        public string CollegeName { get; set; }
        public string City { get; set; }
        public SmartCodeDto State { get; set; }
        public string ZipCode { get; set; }
    }
}