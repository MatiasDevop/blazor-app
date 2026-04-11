using System;
using System.Collections.Generic;
using Enums;

namespace ViewModels.Dtos;

public class JobPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public Guid RecruiterId { get; set; }
    public JobType? JopType { get; set; }
    public Guid CompanyId { get; set; }
    public DateTime DateToPost { get; set; }
    public DateTime DateToExpire { get; set; }
    
    public string Description { get; set; }
    public List<JobRequirementGroupDto> JobRequirementGroups { get; set; }

    public string CompensationDetails { get; set; }
    public string SalaryOffered { get; set; }
    public List<JobBenefitDto> JobBenefits { get; set; }
    
    public bool UseCpccApply { get; set; }
    public string ApplyUrl { get; set; }
    public bool IsActive { get; set; }
    public PartnerPlanDto PartnerPlan { get; set; }
    public List<ApplicationQuestionDto> Questions { get; set; }
}