# Task 2: MediatR Handlers Implementation

## ✅ Status: Partially Complete

### Overview

Implemented MediatR request handlers following CQRS pattern to handle business logic for job postings and job applications. Handlers act as the intermediary between API controllers and the database layer.

---

## 📁 What Was Created

### Handlers Implemented

#### 1. JobPost Handlers (`Portal.Api/Handlers/JobPosts/`)

**CreateJobPostHandler.cs**

- **Purpose**: Creates new job postings with requirements, benefits, and application questions
- **Request**: `CreateJobPostRequest` with `CreateJobPostAction`
- **Response**: `CreateJobPostResult` with created `JobPostDto`
- **Features**:
  - Validates company exists before creating post
  - Maps requirement groups, benefits, and questions
  - Returns full job post DTO with all related data

**GetJobPostHandler.cs**

- **Purpose**: Retrieves individual job post by ID with all related data
- **Request**: `GetJobPostRequest` with job ID and show inactive flag
- **Response**: `GetJobPostResult` with `JobPostDto`
- **Features**:
  - Includes requirement groups, benefits, questions, company profile
  - Option to show inactive job posts
  - Returns 404 if not found

#### 2. JobApplication Handlers (`Portal.Api/Handlers/JobApplications/`)

**CreateJobApplicationHandler.cs**

- **Purpose**: Handles user's application to a job post
- **Request**: `CreateJobApplicationRequest` with `JobApplicationDto`
- **Response**: `CreateJobApplicationResult` with created application
- **Features**:
  - Validates job post exists and is active
  - Prevents duplicate applications (user can apply once per job)
  - Sets initial status to `NotTracked`
  - Captures cover letter

**GetJobApplicationsForUserHandler.cs**

- **Purpose**: Retrieves all job applications for a specific user
- **Request**: `GetJobApplicationsForUserRequest` with user ID
- **Response**: `GetJobApplicationsForUserResult` with list of applications
- **Features**:
  - Includes related job post and company information
  - Ordered by most recent first
  - Handles Enum parsing for application status

### API Controllers

**JobPostsController.cs** (`Portal.Api/Controllers/`)

- **Endpoints**:
  - `GET /api/jobposts/{id}` - Get job post by ID
  - `POST /api/jobposts` - Create new job post
- **Features**:
  - Proper error handling (404 for not found, 400 for bad request, 500 for server errors)
  - Logging for all operations
  - Uses MediatR for request dispatch

**JobApplicationsController.cs** (`Portal.Api/Controllers/`)

- **Endpoints**:
  - `GET /api/jobapplications/user/{userId}` - Get all applications for user
  - `POST /api/jobapplications` - Submit new application
- **Features**:
  - Comprehensive error handling
  - CreatedAtAction response for POST
  - Request/response logging

---

## 🔧 Configuration Changes

### Program.cs Updates

```csharp
// Added MediatR registration
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
```

**MediatR Configuration**:

- Auto-discovers all handlers in Portal.Api assembly
- Enables dependency injection for IMediator
- Handlers automatically resolved when requests are sent

---

## 🎯 Key Implementation Details

### Entity-to-DTO Mapping Patterns

**JobPost Entity** → **JobPostDto**

```
JobTitle → Title
JobLocation → Location
CompanyProfileId → CompanyId
Type → JopType (note: typo in DTO)
DatePosted → DateToPost
ExpirationDate → DateToExpire
UseCpccApplyNow → UseCpccApply
```

**JobRequirementGroup** → **JobRequirementGroupDto**

```
Name/Label → Label (DTO uses Label only)
Order → Order
```

**JobBenefit** → **JobBenefitDto**

```
Text/Name → Text (DTO uses Text only)
```

**ApplicationQuestion** → **ApplicationQuestionDto**

```
Text/Question → Text (DTO uses Text only)
```

**JobApplication** → **JobApplicationDto**

```
UserProfileId → ApplicantId
AppliedAt/DateApplied → DateApplied
Status (string) → Status (enum)
```

### Business Rules Implemented

1. **Job Post Creation**:
   - Company must exist
   - All nested collections (requirements, benefits, questions) created atomically
   - Timestamps set automatically

2. **Job Application Creation**:
   - Job post must exist
   - Job post must be active
   - No duplicate applications per user per job
   - Initial status: `NotTracked`

3. **Job Post Retrieval**:
   - Can filter by active/inactive status
   - Eager loads all related data (requirements, benefits, questions, company)

4. **Job Applications Retrieval**:
   - Sorted by most recent first
   - Includes job and company details
   - Handles status enum parsing gracefully

---

## 🔍 Technical Decisions

### 1. Status Handling

- **Issue**: JobApplicationStatus enum has no "Submitted" value
- **Solution**: Using `NotTracked` as initial status
- **Available Statuses**: NotAFit, GoodFit, InterviewDesired, InterviewScheduled, OfferExtended, Hired, NotTracked

### 2. Property Name Mismatches

- **Issue**: Entity and DTO property names differ
- **Solution**: Explicit mapping in handlers (e.g., `Name`/`Label` → `Label`)
- **Future**: Consider AutoMapper for complex transformations

### 3. Nullable Reference Handling

- **Warnings**: 3 nullable reference warnings (non-critical)
- **Location**: DTO property assignments from possibly null entity properties
- **Status**: Safe to ignore (EF Core ensures required navigation properties loaded)

### 4. Enum to String Conversion

- **Pattern**: `Enum.GetName(JobApplicationStatus.NotTracked)` for DB storage
- **Pattern**: `Enum.Parse<JobApplicationStatus>(status)` for DTO mapping
- **Rationale**: Database stores as string, application uses type-safe enums

---

## ⏭️ What's Next (Not Yet Implemented)

### User Profile Handlers

- RegisterStudentHandler
- RegisterCompanyHandler
- RegisterCareerCenterHandler
- UpdateUserProfileHandler
- GetUserProfileHandler
- GetCompaniesForUserHandler

### Company/School Handlers

- UpdateCompanyProfileHandler
- CreateSchoolHandler
- UpdateSchoolProfileHandler

### Additional JobPost Handlers

- UpdateJobPostHandler
- DeleteJobPostHandler (soft delete)
- SearchJobPostsHandler
- GetJobPostsForCompanyHandler

### Matching & Connection Handlers

- SearchMatchesHandler
- CreateConnectionHandler
- GetConnectionsForUserHandler
- BlockUserHandler

### Authentication-Related Handlers

- LoginHandler (if needed)
- RefreshTokenHandler
- LogoutHandler

---

## 📊 Current API Coverage

| Feature          | Handlers | Controllers | Status |
| ---------------- | -------- | ----------- | ------ |
| Job Posts        | 2/5      | ✅          | 40%    |
| Job Applications | 2/4      | ✅          | 50%    |
| User Profiles    | 0/6      | ❌          | 0%     |
| Companies        | 0/3      | ❌          | 0%     |
| Schools          | 0/3      | ❌          | 0%     |
| Connections      | 0/4      | ❌          | 0%     |
| Matching         | 0/2      | ❌          | 0%     |
| Authentication   | 0/3      | ❌          | 0%     |

**Overall Progress**: ~15% of planned handlers implemented

---

## 🧪 Testing Notes

### Manual Testing via Swagger/OpenAPI

1. Start API: `cd Portal.Api && dotnet run`
2. Navigate to: `http://localhost:5130/swagger` (if Swagger UI enabled)
3. Test endpoints:
   - `POST /api/jobposts` - Create test job post
   - `GET /api/jobposts/{id}` - Retrieve created post
   - `POST /api/jobapplications` - Submit application
   - `GET /api/jobapplications/user/{userId}` - Get user's applications

### Database Verification

```bash
# Connect to database
./db.sh psql

# Check created job posts
SELECT "Id", "JobTitle", "CompanyProfileId", "IsActive" FROM "JobPosts";

# Check job applications
SELECT "Id", "JobPostId", "UserProfileId", "Status", "DateApplied" FROM "JobApplications";
```

---

## 🐛 Known Issues

### Minor Issues

1. **Nullable warnings**: 3 warnings about possible null assignments in DTOs (safe to ignore)
2. **Typo in DTO**: `JopType` should be `JobType` in JobPostDto (inherited from original code)

### Missing Functionality

1. **Update handlers**: No update logic for job posts yet
2. **Delete handlers**: No soft delete for job posts
3. **Search**: No full-text search implementation
4. **Pagination**: Job applications return all results (no paging yet)
5. **Validation**: FluentValidation not yet integrated with handlers

---

## 📝 Build Status

```bash
Build succeeded with 3 warning(s)

Warnings:
- CS8601: Possible null reference assignment (3 occurrences)

All handlers compile successfully ✅
All controllers compile successfully ✅
MediatR registration successful ✅
```

---

## 🔗 Dependencies

- **MediatR** 14.0 - CQRS pattern implementation
- **EF Core** 10.0.5 - Database access
- **Npgsql** - PostgreSQL provider
- **ASP.NET Core** 10.0 - Web framework

---

## ✨ Best Practices Followed

1. **Separation of Concerns**: Handlers contain business logic, controllers handle HTTP concerns
2. **Single Responsibility**: Each handler handles one request type
3. **Logging**: Comprehensive logging at info, warning, and error levels
4. **Error Handling**: Specific exception types (KeyNotFoundException, InvalidOperationException)
5. **Async/Await**: All database operations are async
6. **Dependency Injection**: All dependencies injected via constructor
7. **Request/Response Pattern**: Consistent use of MediatR request/result pattern
8. **Immutability**: Request/Result objects use readonly patterns where possible

---

**Last Updated**: April 11, 2026  
**Status**: Foundational handlers in place, ready for expansion  
**Next Priority**: User Profile registration handlers (critical for authentication)
