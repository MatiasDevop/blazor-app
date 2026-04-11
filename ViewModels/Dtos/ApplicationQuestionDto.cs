using System;
using System.Collections.Generic;

namespace ViewModels.Dtos;

public class ApplicationQuestionDto
{
    public Guid Id { get; set; }
    public Guid JobPostId { get; set; }
    public string Text { get; set; }
    public List<JobApplicationAnswerDto> Answers { get; set; }
}