using System;

namespace ViewModels.Dtos;

public class JobRequirementDto
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public string Text { get; set; }
}