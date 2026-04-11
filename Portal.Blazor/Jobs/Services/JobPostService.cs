using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Xpo.Logger;
using Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Portal.Blazor.Components.Modals;
using Portal.Blazor.Extensions;
using Portal.Blazor.Services;
using Portal.Blazor.Rcl.Permissions.Enums;
using Portal.Rcl.Permissions.Models;
using Portal.Rcl.Permissions.Services;
using ViewModels.Dtos;
using ViewModels.HttpRequests.JobPosts;
using ViewModels.Requests.Endpoints.Companies;
using ViewModels.Requests.Endpoints.JobPosts;
using ViewModels.Weavy.Model;

namespace Portal.Blazor.Jobs.Services;

public class JobPostService : IDisposable
{
    private readonly CompanyService _companyService;
    private readonly IOrgSelectionService _orgSelectionService;
    private readonly ILogger<JobPostService> _logger;
    private readonly NavigationManager _navigationManager;
    private readonly HttpClient _httpClient;
    private readonly HttpClient _securedHttpClient;
    private readonly HttpClient _orgEnabledHttpClient;
    private readonly List<IDisposable> subscriptions = new List<IDisposable>();
    private readonly ToastService _toastService;
    private readonly LoadingService _loadingService;
    private readonly Blazored.Modal.Services.IModalService _modalService;

    private readonly BehaviorSubject<JobPostDto> newPost = new BehaviorSubject<JobPostDto>(null);
    public IObservable<JobPostDto> NewPost => newPost;


    private readonly BehaviorSubject<FullCompanyDto> _userCurrentCompany = new(null);
    public IObservable<FullCompanyDto> UserCurrentCompany => _userCurrentCompany;

    private readonly BehaviorSubject<IEnumerable<FullOrgUserConnectionDto>> _currentOrgUserConnections =
        new(new List<FullOrgUserConnectionDto>());

    public IObservable<IEnumerable<FullOrgUserConnectionDto>> CurrentOrgUserConnections => _currentOrgUserConnections;

    private static readonly BehaviorSubject<bool> _currentOrgNotSupported = new(false);
    public IObservable<bool> CurrentOrgNotSupported => _currentOrgNotSupported;
    private readonly BehaviorSubject<List<JobPostDto>> _jobPosts = new(null);
    public IObservable<List<JobPostDto>> JobPosts => _jobPosts;


    private readonly BehaviorSubject<SearchJobsAction> query = new(new());
    public IObservable<SearchJobsAction> Query => query;
    private readonly BehaviorSubject<List<JobPostDto>> _jobPostList = new(new());
    public IObservable<List<JobPostDto>> JobsPostList => _jobPostList;
    private readonly BehaviorSubject<JobPostDto> _currentJobPost = new(null);
    public IObservable<JobPostDto> CurrentJobPost => _currentJobPost;

    public JobPostService(
        IHttpClientFactory httpClientFactory,
        CompanyService companyService,
        IOrgSelectionService orgSelectionService,
        ILogger<JobPostService> logger,
        NavigationManager navigationManager,
        ToastService toastService,
        LoadingService loadingService,
        Blazored.Modal.Services.IModalService modalService
    )
    {
        logger.LogInformation($"[constructor] - Constructing Job Post Service");
        _companyService = companyService;
        _orgSelectionService = orgSelectionService;
        _logger = logger;
        _navigationManager = navigationManager;
        _httpClient = httpClientFactory.CreateClient(DefaultHttpClients.Unsecured);
        _securedHttpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        _toastService = toastService;
        _loadingService = loadingService;
        _modalService = modalService;

        _logger.LogInformation($"[constructor] - Adding Subscription to Current Org on OrgSelectionService");

        subscriptions.Add(_orgSelectionService.CurrentOrg.Subscribe(CurrentOrgChanged));
    }

    private async void CurrentOrgChanged(OrgSelectionItem org)
    {
        _logger.LogInformation($"[CurrentOrgChanged] - Argument org = {JsonSerializer.Serialize(org)}");

        if (org == null || org.Id == Guid.Empty || org.Type == null)
        {
            _logger.LogInformation($"[CurrentOrgChanged] - Null Org Detected, Exiting Code");
            return;
        }

        if (org.Type == OrgType.Company)
        {
            try
            {
                _logger.LogInformation($"[CurrentOrgChanged] - Loading Data on CurrentOrgChanged");
                var companyDto = await _securedHttpClient.GetFromJsonAsync<FullCompanyDto>($"Company/{org.Id}");
                _logger.LogInformation($"[CurrentOrgChanged] - Company DTO Acquired; Building OrgHttpClient");
                var orgClient = _orgSelectionService.GetOrgHttpClient();

                if (orgClient == null)
                {
                    _logger.LogInformation(
                        $"[CurrentOrgChanged] - Unable to retrieve Org Http Client, Canceling Attempt");
                    return;
                }

                _logger.LogInformation($"[CurrentOrgChanged] - OrgHttpClient Ready; Requesting Org Users");
                var users = await orgClient.GetFromJsonAsync<GetOrgUsersForOrgIdResult>("Company/org-users");

                _logger.LogInformation($"[CurrentOrgChanged] - Setting Company and Users");
                _userCurrentCompany.OnNext(companyDto);
                _currentOrgUserConnections.OnNext(users?.OrgUsers);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"[CurrentOrgChanged] - Unable to get data from API");
            }
        }
        else
        {
            _logger.LogInformation($"[CurrentOrgChanged] - Current Org does not support creating Jobs");
            _currentOrgNotSupported.OnNext(true);
            _navigationManager.NavigateTo($"/career-center/{org.Id}");
        }
    }

    public void UpdateNewJobPostRecord(JobPostDto newPostRecord)
    {
        newPost.OnNext(newPostRecord);
    }

    public async void PersistJobPostAsync(JobPostDto newJobPost,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _loadingService.Show();

            var client = _orgSelectionService.GetOrgHttpClient();
            if (client != null)
            {
                //Temp Fix for timezone 
                newJobPost.DateToPost = newJobPost.DateToPost.Date.AddHours(5);
                newJobPost.DateToExpire = newJobPost.DateToExpire.Date.AddHours(5);
            
                var response = await client.PostAsJsonAsync("JobPost/with-children", newJobPost, cancellationToken);
                if (response.StatusCode == HttpStatusCode.Conflict)
                    throw new ArgumentException(await response.Content.ReadAsStringAsync(cancellationToken));
                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync(cancellationToken));
            }

            _navigationManager.NavigateTo($"/company/{_userCurrentCompany.Value.Id}");
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"[PersistJobPostAsync] - Unable to post data to API");
        }
        finally
        {
          _loadingService.Hide();
        }
    }

    public async void SearchJobPosts()
    {
        var jobs = await _securedHttpClient.GetFromJsonAsync<JobSearchResult>(QueryStringHelper.Build("JobPost/search", query.Value));
        if (jobs != null) _jobPostList.OnNext(jobs?.Results.ToList());
    }

    public async void UpdateJobPost(JobPostDto updateJobPost,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _loadingService.Show();

            var client = _orgSelectionService.GetOrgHttpClient();
            if (client != null)
            {
                var response = await client.PutAsJsonAsync($"JobPost/update-job-post", updateJobPost, cancellationToken);
                if (response.StatusCode == HttpStatusCode.Conflict)
                    throw new ArgumentException(await response.Content.ReadAsStringAsync(cancellationToken));
                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync(cancellationToken));
            }
        
            _navigationManager.NavigateTo($"/company/{_userCurrentCompany.Value.Id}");
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"[UpdateJobPost] - Unable to post data to API");
        }
        finally
        {
            _loadingService.Hide();
        }
    }

    public async void GetJobPosts(Guid companyId, bool showLoader = false,bool? showInActives = false, CancellationToken cancellationToken = default)
    {
        try
        {
            if(showLoader) _loadingService.Show();
            
            _jobPosts.OnNext(null);
            var result = await _securedHttpClient.GetFromJsonAsync<GetJobPostsForCompanyResult>(
                    $"JobPost/companyjobs/{companyId}/{showInActives}");
            _jobPosts.OnNext(result?.JobPosts?.ToList());
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"[GetJobPosts] - Unable to get data from API");
        }
        finally
        {
            if (showLoader) _loadingService.Hide();
        }
    }

    public void UpdateSearchJobsQuery(SearchJobsAction newValue)
    {
        query.OnNext(newValue);
        SearchJobPosts();
    }

    private async Task DeleteJobPost(Guid id)
    {
        try
        {
            _loadingService.Show();
            await _httpClient.DeleteAsync($"JobPost/delete/{id}");
        }
        catch (Exception e)
        {
            _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
        }
        finally
        {
            _loadingService.Hide();
        }
    }

    public async Task ShowDeletePostModal(JobPostDto jobPostDto)
    {
        var parameters = new ModalParameters();
        parameters.Add("JobPost", jobPostDto);
        var modal = _modalService.Show<DeleteJobPostModal>("", parameters);
        var result = await modal.Result;
        if (result.Cancelled)
            return;

        await DeleteJobPost(jobPostDto.Id);
    }

    public async Task GetJobPost(Guid id,bool? showInActives = false)
    {
        try
        {
            _loadingService.Show();
            
            _currentJobPost.OnNext(null);
            var result = await _securedHttpClient.GetFromJsonAsync<GetJobPostResult>($"JobPost/{id}/{showInActives}");
            _currentJobPost.OnNext(result.JobPost);
        }
        catch (Exception e)
        {
            _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
        }
        finally
        {
            _loadingService.Hide();
        }
    }
    
    public string GetJobType(JobPostDto jobPostDto)
    {
        if(jobPostDto?.JopType == null) return string.Empty;
        
        return jobPostDto.JopType.GetType()
            .GetMember(jobPostDto.JopType.Value.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetName();
    }
    
    public void Dispose()
    {
        _httpClient?.Dispose();
        newPost?.Dispose();
    }
}

