using ViewModels.Dtos;

namespace ViewModels.ViewModels
{
    public class CareerCenterCardViewModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public AttachmentDto Logo { get; set; }
    }
}