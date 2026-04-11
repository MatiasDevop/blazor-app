using System.ComponentModel.DataAnnotations;

namespace Enums;

public enum Frequency
{
    [Display(Name = "Monthly")] Monthly,
    [Display(Name = "Yearly")] Yearly
}