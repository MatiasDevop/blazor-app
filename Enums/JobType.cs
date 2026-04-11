using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Enums;

public enum JobType
{
    [Display(Name = "Unpaid Internship")]
    UnpaidInternship,
    [Display(Name = "Paid Internship")]
    PaidInternship,
    [Display(Name = "Part-Time Hourly")]
    PartTimeHourly,
    [Display(Name = "Part-Time Salary")]
    PartTimeSalary,
    [Display(Name = "Full-Time Hourly")]
    FullTimeHourly,
    [Display(Name = "Full-Time Salary")]
    FullTimeSalary,
    [Display(Name = "Part-Time Contractor")]
    PartTimeContractor,
    [Display(Name = "Full-Time Contractor")]
    FullTimeContractor
}