using System;

namespace ViewModels.Dtos;

public class JobApplicationAnswerDto
{
    public Guid Id { get; set; }
    public Guid JobApplicationId { get; set; }
    public Guid QuestionId { get; set; }
    public string AnswerText { get; set; }
}