using System;
using System.Collections.Generic;

namespace ViewModels.Dtos;

public class JobRequirementGroupDto
{
    public Guid Id { get; set; }
    public Guid JobPostId { get; set; }
    public string Label { get; set; }
    public int Order { get; set; }
    public List<JobRequirementDto> Requirements { get; set; }
}