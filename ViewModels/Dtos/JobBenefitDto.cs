using System;

namespace ViewModels.Dtos;

public class JobBenefitDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid JopPostId { get; set; }
}