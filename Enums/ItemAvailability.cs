using System.ComponentModel.DataAnnotations;

namespace Enums;

public enum ItemAvailability
{
    [Display(Name="Any")] Any,
    [Display(Name="CareerCenterOnly")] CareerCenterOnly,
    [Display(Name="CompanyOnly")] CompanyOnly
}