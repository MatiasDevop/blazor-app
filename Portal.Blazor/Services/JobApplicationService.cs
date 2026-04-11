using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Enums;
using Microsoft.Extensions.Logging;
using Portal.Blazor.Jobs.Components.Modals;
using ViewModels.Dtos;
using ViewModels.Requests.Endpoints.JobApplications;

namespace Portal.Blazor.Services;

public class JobApplicationService
{
    private readonly ILogger<JobApplicationService> _logger;
    private readonly HttpClient _securedHttpClient;
    private readonly ToastService _toastService;
    private readonly LoadingService _loadingService;
    private readonly Blazored.Modal.Services.IModalService _modalService;
    private readonly BehaviorSubject<JobApplicationDto> jobApplicationForApplicant = new(null);
    public IObservable<JobApplicationDto> JobApplicationForApplicant => jobApplicationForApplicant;
    private readonly BehaviorSubject<List<JobApplicationDto>> jobApplicationsForApplicant = new(null);
    public IObservable<List<JobApplicationDto>> JobApplicationsForApplicant => jobApplicationsForApplicant;
    private readonly BehaviorSubject<List<JobApplicationDto>> jobApplicationsForJobPost = new(null);
    public IObservable<List<JobApplicationDto>> JobApplicationsForJobPost => jobApplicationsForJobPost;

    public JobApplicationService(
        IHttpClientFactory httpClientFactory,
        ILogger<JobApplicationService> logger,
        ToastService toastService,
        LoadingService loadingService,
        Blazored.Modal.Services.IModalService modalService)
    {
        _logger = logger;
        _securedHttpClient = httpClientFactory.CreateClient(DefaultHttpClients.Secured);
        _toastService = toastService;
        _loadingService = loadingService;
        _modalService = modalService;
    }

    public async Task<bool> CreateJobApplication(JobApplicationDto jobApplicationDto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"[CreateJobApplication] - Invoked");

        try
        {
            _loadingService.Show();
            _logger.LogInformation($"[CreateJobApplication] - Sending request");

            var response =
                await _securedHttpClient.PostAsJsonAsync("jobapplications", jobApplicationDto, cancellationToken);
            _logger.LogInformation($"[CreateJobApplication] - Response received");

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync(cancellationToken));

            _logger.LogInformation($"[CreateJobApplication] - Job Application created");
            return true;
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"[CreateJobApplication] - Job Application cannot be created");
            _toastService.ShowToast(e.Message, ToastLevel.Error, "Unknown Error");
        }
        finally
        {
            _loadingService.Hide();
        }

        return false;
    }

    public async Task GetJobApplicationForApplicant(Guid jobPostId, Guid applicantId)
    {
        _logger.LogInformation($"[GetJobApplicationForApplicant] - Invoked");

        try
        {
            jobApplicationForApplicant.OnNext(null);

            _logger.LogInformation($"[GetJobApplicationForApplicant] - Sending request");
            var result = await _securedHttpClient.GetFromJsonAsync<GetJobApplicationForUserResult>($"JobApplication/job-post/{jobPostId}/applicant/{applicantId}");

            _logger.LogInformation($"[GetJobApplicationForApplicant] - Response received");
            jobApplicationForApplicant.OnNext(result?.JobApplication);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"[GetJobApplicationForApplicant] - Cannot fetch Job Application");
        }

    }

    public async Task GetJobApplicationsForApplicant(Guid applicantId)
    {
        _logger.LogInformation($"[GetJobApplicationsForApplicant] - Invoked");

        try
        {
            _logger.LogInformation($"[GetJobApplicationsForApplicant] - Sending request");
            var result = await _securedHttpClient.GetFromJsonAsync<List<JobApplicationDto>>($"jobapplications/user/{applicantId}");

            _logger.LogInformation($"[GetJobApplicationsForApplicant] - Response received");
            jobApplicationsForApplicant.OnNext(result);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"[GetJobApplicationsForApplicant] - Cannot fetch Job Application");
        }

    }

    public async Task GetJobApplicationsForJobPost(Guid jobPostId)
    {
        _logger.LogInformation($"[GetJobApplicationsForJobPost] - Invoked");

        try
        {
            jobApplicationsForJobPost.OnNext(null);
            _logger.LogInformation($"[GetJobApplicationsForJobPost] - Sending request");
            var result = await _securedHttpClient.GetFromJsonAsync<GetJobApplicationsForJobPostResult>($"JobApplication/job-post/{jobPostId}");

            _logger.LogInformation($"[GetJobApplicationsForJobPost] - Response received");
            jobApplicationsForJobPost.OnNext(result?.JobApplications);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"[GetJobApplicationsForJobPost] - Cannot fetch Job Applications");
        }

    }

    public async Task UpdateApplicantStatus(JobApplicationDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"[UpdateApplicantStatus] - Invoked");

        try
        {
            _logger.LogInformation($"[UpdateApplicantStatus] - Sending request");
            var response = await _securedHttpClient.PutAsJsonAsync($"JobApplication/update-status", dto);
            if (response.StatusCode == HttpStatusCode.Conflict)
                throw new ArgumentException(await response.Content.ReadAsStringAsync(cancellationToken));
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync(cancellationToken));

        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"[UpdateApplicantStatus] - Cannot Execute Update Status");
        }

    }

    public async Task ViewApplicant(JobApplicationDto jobApplication)
    {
        if (jobApplication.JobPost.UseCpccApply)
        {
            if (jobApplication.Status is JobApplicationStatus.NotTracked)
            {
                var parameters = new ModalParameters();
                parameters.Add(nameof(ApplicantForReviewModal.JobApplication), jobApplication);
                var modal = _modalService.Show<ApplicantForReviewModal>("", parameters);
                var result = await modal.Result;
                if (result.Cancelled)
                    return;

                if (result.Data != null)
                {
                    if ((JobApplicationStatus)result.Data is JobApplicationStatus.GoodFit)
                    {
                        var secondParams = new ModalParameters();
                        secondParams.Add(nameof(ApplicantForInterestedModal.JobApplication), jobApplication);
                        var modalTwo = _modalService.Show<ApplicantForInterestedModal>("", secondParams);
                        var resultTwo = await modalTwo.Result;
                        if (resultTwo.Cancelled)
                            return;
                    }
                    if ((JobApplicationStatus)result.Data is JobApplicationStatus.NotAFit)
                    {
                        var thirdParams = new ModalParameters();
                        thirdParams.Add(nameof(ApplicantForNotInterestedModal.JobApplication), jobApplication);
                        var modalThree = _modalService.Show<ApplicantForNotInterestedModal>("", thirdParams);
                        var resultThree = await modalThree.Result;
                        if (resultThree.Cancelled)
                            return;
                    }
                }
            }
            if (jobApplication.Status is JobApplicationStatus.GoodFit)
            {
                var parameters = new ModalParameters();
                parameters.Add(nameof(ApplicantForInterestedModal.JobApplication), jobApplication);
                var modal = _modalService.Show<ApplicantForInterestedModal>("", parameters);
                var result = await modal.Result;
                if (result.Cancelled)
                    return;
            }
            if (jobApplication.Status is JobApplicationStatus.NotAFit)
            {
                var parameters = new ModalParameters();
                parameters.Add(nameof(ApplicantForNotInterestedModal.JobApplication), jobApplication);
                var modal = _modalService.Show<ApplicantForNotInterestedModal>("", parameters);
                var result = await modal.Result;
                if (result.Cancelled)
                    return;
            }
        }
        else
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(ApplicantNoCpccModal.JobApplication), jobApplication);
            var modal = _modalService.Show<ApplicantNoCpccModal>("", parameters);
            var result = await modal.Result;
            if (result.Cancelled)
                return;
        }
    }

    public string GetPronounLocation(JobApplicationDto jobApplication)
    {
        string pronoun;
        if (jobApplication.Applicant.Pronouns?.Label == "Other")
            pronoun = jobApplication.Applicant.PronounsIfOther;
        else
            pronoun = jobApplication.Applicant.Pronouns?.Label;

        string location;
        if (!string.IsNullOrWhiteSpace(jobApplication.Applicant.MailingAddress?.City))
        {
            location = !string.IsNullOrWhiteSpace(jobApplication.Applicant.MailingAddress?.State?.Label) ?
                jobApplication.Applicant.MailingAddress?.City + ", " + jobApplication.Applicant.MailingAddress?.State?.Label : jobApplication.Applicant.MailingAddress?.City;
        }
        else
        {
            location = jobApplication.Applicant.MailingAddress?.State?.Label;
        }

        if (!string.IsNullOrWhiteSpace(pronoun))
            return !string.IsNullOrWhiteSpace(location) ? pronoun + " | " + location : pronoun;
        else
            return location;

    }

    public string GetJobApplicantCardBackground(JobApplicationDto jobApplicationDto)
    {
        switch (jobApplicationDto.Status)
        {
            case JobApplicationStatus.NotTracked:
                return "../images/applicant_card_background_under_review.svg";
            case JobApplicationStatus.GoodFit:
                return "../images/applicant_card_background_interested.svg";
            case JobApplicationStatus.NotAFit:
                return "../images/applicant_card_background_not_interested.svg";
            default:
                return String.Empty;
        }
    }
}

