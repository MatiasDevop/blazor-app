using ViewModels.Dtos;
using ViewModels.HttpRequests.JobPosts;

namespace ViewModels.Extensions.Mappings.JobPosts;

public static class JobPostsMappings
{
    public static JobPostDto ToBusinessObject(this CreateJobPostAction action)
    {
        var result = new JobPostDto
        {
            CompanyId = action.CompanyId,
            Description = action.Description,
            Location = action.Location,
            Questions = action.Questions,
            RecruiterId = action.RecruiterId,
            Title = action.Title,
            ApplyUrl = action.ApplyUrl,
            CompensationDetails = action.CompensationDetails,
            JobBenefits = action.JobBenefits,
            JopType = action.JopType,
            SalaryOffered = action.SalaryOffered,
            DateToExpire = action.DateToExpire,
            DateToPost = action.DateToPost,
            JobRequirementGroups = action.JobRequirementGroups,
            UseCpccApply = action.UseCpccApply
        };

        return result;
    }
}