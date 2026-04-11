using System;
using Enums;

namespace ViewModels.HttpRequests.JobPosts;

public class SearchJobsAction
{
    public Guid? IndustryId { get; set; }
    public string? LocationSearch { get; set; }
    public JobType? JobType { get; set; }
    public int? MilesFromLocation { get; set; }
    public JobPostSortingEnum SortBy { get; set; }
    public bool OnlyFollowed { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public string UserEmail { get; set; }
}