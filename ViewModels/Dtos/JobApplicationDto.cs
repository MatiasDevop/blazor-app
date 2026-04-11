using System;
using System.Collections.Generic;
using Enums;

namespace ViewModels.Dtos;

public class JobApplicationDto
{
    public Guid Id { get; set; }
    public Guid JobPostId { get; set; }
    public Guid ApplicantId { get; set; }
    public DateTime DateApplied { get; set; }
    public DateTime DateReviewed { get; set; }
    public JobApplicationStatus Status { get; set; }
    public string CoverLetter { get; set; }
    public JobPostDto JobPost { get; set; }
    public FullUserProfileDto Applicant { get; set; }
    public List<JobApplicationAnswerDto> Answers { get; set; }
}