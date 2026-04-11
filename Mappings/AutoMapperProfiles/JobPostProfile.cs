using AutoMapper;
using Domain.Entities;
using Enums;
using ViewModels.Dtos;
using ViewModels.HttpRequests.JobPosts;

namespace Mappings.AutoMapperProfiles;

public class JobPostProfile : Profile
{
    public JobPostProfile()
    {
        CreateMap<JobPost, JobPostDto>(MemberList.None)
            .ForMember(x => x.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Title,
                opt => opt.MapFrom(src => src.JobTitle))
            .ForMember(x => x.Location,
                opt => opt.MapFrom(src => src.JobLocation))
            .ForMember(x => x.RecruiterId,
                opt => opt.MapFrom(src => src.AssignedRecruiter.Id))
            .ForMember(x => x.JopType,
                opt => opt.MapFrom(src => src.Type))
            .ForMember(x => x.CompanyId,
                opt => opt.MapFrom(src => src.Company.Id))
            .ForMember(x => x.DateToPost,
                opt => opt.MapFrom(src => src.DatePosted))
            .ForMember(x => x.DateToExpire,
                opt => opt.MapFrom(src => src.ExpirationDate))
            .ForMember(x => x.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(x => x.CompensationDetails,
                opt => opt.MapFrom(src => src.CompensationDetails))
            .ForMember(x => x.SalaryOffered,
                opt => opt.MapFrom(src => src.SalaryOffered))
            .ForMember(x => x.UseCpccApply,
                opt => opt.MapFrom(src => src.UseCpccApplyNow))
            .ForMember(x => x.ApplyUrl,
                opt => opt.MapFrom(src => src.ApplyUrl))
            .ForMember(x => x.IsActive,
                opt => opt.MapFrom(src => src.IsActive))
            .ForMember(x => x.Questions,
                opt => opt.MapFrom(src => src.Questions))
            .ForMember(x => x.JobRequirementGroups,
                opt => opt.MapFrom(src => src.RequirementGroups))
            .ForMember(x => x.JobBenefits,
                opt => opt.MapFrom(src => src.Benefits))
            .ForMember(x => x.PartnerPlan,
                opt => opt.MapFrom(src => src.Company.Subscriptions
                    .Where(x => x.Status == SubscriptionStatus.Active)
                    .Select(x => x.Plan)
                    .FirstOrDefault()));

        CreateMap<EditJobPostAction, JobPost>(MemberList.None)
            .ForMember(x => x.JobTitle,
                opt => opt.MapFrom(src => src.Title))
            .ForMember(x => x.JobLocation,
                opt => opt.MapFrom(src => src.Location))
            .ForMember(x => x.AssignedRecruiter,
                opt => opt.Ignore())
            .ForMember(x => x.Type,
                opt => opt.MapFrom(src => src.JopType))
            .ForMember(x => x.Company,
                opt => opt.Ignore())
            .ForMember(x => x.DatePosted,
                opt => opt.MapFrom(src => src.DateToPost))
            .ForMember(x => x.ExpirationDate,
                opt => opt.MapFrom(src => src.DateToExpire))
            .ForMember(x => x.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(x => x.CompensationDetails,
                opt => opt.MapFrom(src => src.CompensationDetails))
            .ForMember(x => x.SalaryOffered,
                opt => opt.MapFrom(src => src.SalaryOffered))
            .ForMember(x => x.UseCpccApplyNow,
                opt => opt.MapFrom(src => src.UseCpccApply))
            .ForMember(x => x.ApplyUrl,
                opt => opt.MapFrom(src => src.ApplyUrl))
            .ForMember(x => x.IsActive,
                opt => opt.MapFrom(src => src.IsActive))
            .ForMember(x => x.Questions,
                opt => opt.MapFrom(src => src.Questions))
            .ForMember(x => x.RequirementGroups,
                opt => opt.MapFrom(src => src.JobRequirementGroups))
            .ForMember(x => x.Benefits,
                opt => opt.MapFrom(src => src.JobBenefits));
    }
}