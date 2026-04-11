using System.ComponentModel.DataAnnotations;

namespace Enums;

public enum JobPostSortingEnum
{
    [Display(Name = "Relevance Based On Profile")]
    RelevanceBasedOnProfile,
    [Display(Name = "Company Name")]
    CompanyName,
    [Display(Name = "Job Title")]
    JobTitle,
    [Display(Name = "Date Posted")]
    DatePosted
}