# Docker + Database Setup - COMPLETED ✅

## Summary

Successfully set up Docker environment with PostgreSQL, created database schema with EF Core migrations, and seeded reference data. All 52 entities are now persisted in a containerized PostgreSQL database.

---

## What Was Implemented

### 1. Docker Compose Configuration

**File:** [docker-compose.yml](docker-compose.yml)

**Services:**

- **postgres** - PostgreSQL 17 Alpine (lightweight, production-grade)

**Features:**

- Health checks for PostgreSQL readiness
- Persistent volumes for data
- Environment variable configuration via `.env`
- Network isolation with custom bridge network

**Ports Exposed:**

- PostgreSQL: `5432`

### 2. Environment Configuration

**Files:**

- [.env](.env) - Local development credentials (git-ignored)
- [.env.example](.env.example) - Template for team members

**Database:**

- Name: `cpcc_campus_app_dev`
- User: `postgres`
- Password: `postgres` (change for production!)

### 3. EF Core Migration

**Migration:** `20260411120850_InitialCreate`
**Location:** `Portal.Api/Migrations/`

**Created 53 Tables:**

- 52 domain entity tables
- 1 EF migrations history table

**Sample Tables:**

```
UserProfiles, CompanyProfiles, Schools, JobPosts, JobApplications,
PartnerPlans, PartnershipSubscriptions, PaymentMethods, InvoiceHeaders,
SmartTypes, SmartCodes, UserConnections, Addresses, EducationHistories,
WorkHistories, CompanyClaims, SchoolClaims, and 36 more...
```

### 4. Seed Data Implementation

**File:** [Portal.Api/Data/Seeds/SmartTypesSeeder.cs](Portal.Api/Data/Seeds/SmartTypesSeeder.cs)

**Seeded 10 SmartTypes:**

1. **State** (Geography) - 51 US states/territories
2. **GenderIdentity** (Demographics) - 10 options
3. **SexualOrientation** (Demographics) - 10 options
4. **PrimaryLanguage** (Communication) - 16 languages
5. **RaceEthnicity** (Demographics) - 9 options
6. **Pronouns** (Demographics) - 7 pronoun sets
7. **OrganizationSize** (Business) - 8 size ranges
8. **Industry** (Business) - 19 industries
9. **DegreeLevel** (Education) - 9 degree types
10. **Skills** (Professional) - 18 common skills

**Total SmartCodes:** 157 reference data entries

### 5. Automatic Seeding on Startup

**Updated:** [Portal.Api/Program.cs](Portal.Api/Program.cs)

Development mode now automatically:

- Applies pending migrations
- Seeds reference data (SmartTypes/SmartCodes)
- Logs seeding progress to console

---

## Docker Commands

### Start Services

```bash
# Start PostgreSQL only
docker-compose up -d postgres

# View logs
docker-compose logs -f postgres
```

### Stop Services

```bash
# Stop all services
docker-compose down

# Stop and remove volumes (⚠️ deletes all data)
docker-compose down -v
```

### Database Management

```bash
# Connect to PostgreSQL CLI
docker exec -it cpcc_postgres psql -U postgres -d cpcc_campus_app_dev

# View all tables
docker exec cpcc_postgres psql -U postgres -d cpcc_campus_app_dev -c "\dt"

# Count records in SmartTypes
docker exec cpcc_postgres psql -U postgres -d cpcc_campus_app_dev -c "SELECT COUNT(*) FROM \"SmartTypes\";"

# Backup database
docker exec cpcc_postgres pg_dump -U postgres cpcc_campus_app_dev > backup.sql

# Restore database
docker exec -i cpcc_postgres psql -U postgres -d cpcc_campus_app_dev < backup.sql
```

## EF Core Migration Commands

### Create New Migration

```bash
cd Portal.Api
dotnet ef migrations add MigrationName
```

### Apply Migrations

```bash
cd Portal.Api
dotnet ef database update
```

### Rollback Migration

```bash
cd Portal.Api
dotnet ef database update PreviousMigrationName
```

### Remove Last Migration (if not applied)

```bash
cd Portal.Api
dotnet ef migrations remove
```

### Generate SQL Script

```bash
cd Portal.Api
dotnet ef migrations script > migration.sql
```

---

## Running the Application

### Option 1: API Locally, PostgreSQL in Docker

```bash
# Start PostgreSQL
docker-compose up -d postgres

# Run API
cd Portal.Api
dotnet run
```

API will be available at: `http://localhost:5130`

### Option 2: Everything in Docker (Future Enhancement)

Uncomment the `api` service in docker-compose.yml and run:

```bash
docker-compose up -d
```

---

## Database Schema Highlights

### Entity Relationships Configured

**User Management:**

- UserProfile → (1:N) → JobApplications, WorkHistories, EducationHistories
- UserProfile ↔ (N:N self-referencing) ↔ UserConnection (Requester/Recipient pattern)
- UserProfile → (1:N) → UserBlocks (Blocker/Blocked pattern)

**Job System:**

- CompanyProfile → (1:N) → JobPosts
- JobPost → (1:N) → JobApplications
- JobApplication → (1:N) → JobApplicationAnswers

**Partnership & Billing:**

- CompanyProfile → (1:N) → PartnershipSubscriptions
- PartnerPlan → (1:N) → PlanPrices (effective dating)
- CompanyClaim → (1:N) → InvoiceHeaders → InvoiceDetails

**Reference Data:**

- SmartType → (1:N) → SmartCodes (lookup system)
- Used for dropdowns: States, Gender, Languages, etc.

### Special Configurations Applied

**Ignored Properties** (to avoid EF ambiguity):

- `CompanyMultiSelection.Value` (duplicate of SmartCode)
- `PotentialConnection.Match` (duplicate of UserProfile)
- `EducationHistory.Majors/Minors` (needs join table - future enhancement)

**Nullable Foreign Keys:**

- `WorkHistory.CompanyProfileId` (optional company reference)
- `WorkHistory.SchoolId` (optional career center reference)

**Delete Behaviors:**

- **Cascade**: When parent owns child (UserProfile → WorkHistories)
- **Restrict**: Prevent orphans (JobPost → Applicant)
- **SetNull**: Optional relationships (CompanyClaim → Address)

---

## Verification Tests

### 1. Tables Created

```sql
SELECT COUNT(*) FROM information_schema.tables
WHERE table_schema = 'public';
-- Expected: 53 tables
```

### 2. Reference Data Loaded

```sql
SELECT COUNT(*) FROM "SmartTypes";  -- Expected: 10
SELECT COUNT(*) FROM "SmartCodes";  -- Expected: 157
```

### 3. Sample Query - List All States

```sql
SELECT sc."Code", sc."Label"
FROM "SmartCodes" sc
JOIN "SmartTypes" st ON sc."SmartTypeId" = st."Id"
WHERE st."Name" = 'State'
ORDER BY sc."Label";
```

### 4. Check Migrations Applied

```sql
SELECT * FROM "__EFMigrationsHistory";
-- Should show: 20260411120850_InitialCreate
```

---

## Troubleshooting

### PostgreSQL Won't Start

```bash
# Check container status
docker-compose ps

# View logs
docker-compose logs postgres

# Restart
docker-compose restart postgres
```

### Migration Errors

```bash
# Check DbContext can be created
cd Portal.Api
dotnet ef dbcontext info

# Rebuild project
dotnet clean && dotnet build

# Check connection string
cat appsettings.Development.json | grep ConnectionStrings -A2
```

### Can't Connect to Database

```bash
# Test from container
docker exec cpcc_postgres pg_isready -U postgres

# Test from host
psql -h localhost -p 5432 -U postgres -d cpcc_campus_app_dev
```

### Seed Data Not Loading

```bash
# Check if data already exists
docker exec cpcc_postgres psql -U postgres -d cpcc_campus_app_dev -c "SELECT COUNT(*) FROM \"SmartTypes\";"

# Clear and re-seed
docker-compose down -v
docker-compose up -d postgres
cd Portal.Api
dotnet ef database update
dotnet run
```

---

## Next Steps (Task 3+)

### 1. Create MediatR Handlers ✅ Ready

- Infrastructure is in place
- ViewModels.csproj already references MediatR 14.0
- Need to implement handlers for 22 commands + expand queries

### 2. Build API Controllers ✅ Ready

- Database layer complete
- Can now create controllers for:
  - UserProfileController
  - JobPostController
  - CompanyController
  - MatchingController
  - SearchController

### 3. Implement Authentication ✅ Ready

- Add Auth0 JWT bearer validation
- Map claims to UserProfile
- Implement authorization policies

### 4. Join Table Migrations (Enhancement)

- EducationHistory ↔ EducationFocus (Majors/Minors)
- CompanyClaim ↔ WorkAuthorizationType (many-to-many)

---

## Architecture Achievements

✅ **Containerized PostgreSQL** - Consistent dev environment  
✅ **All 52 entities** - Fully mapped with EF Core  
✅ **Automatic migrations** - Database evolves with code  
✅ **Reference data seeded** - 157 dropdown options ready  
✅ **Proper relationships** - Foreign keys, indexes, constraints  
✅ **Delete behaviors** - Data integrity enforced  
✅ **Health checks** - Database readiness monitoring  

---

## Build & Test Status

**Portal.Api Build:** ✅ Success (0 errors, 344 nullable warnings in ViewModels)  
**Database Status:** ✅ Healthy (53 tables, 10 SmartTypes, 157 SmartCodes)  
**Docker Status:** ✅ Running (postgres container healthy)  
**Migrations Status:** ✅ Applied (InitialCreate migration successful)  
**Seeding Status:** ✅ Complete (automatic on startup in dev mode)

**Test Results:**

```
✓ PostgreSQL 17 running in Docker
✓ Database created: cpcc_campus_app_dev
✓ 53 tables created successfully
✓ 10 SmartTypes seeded
✓ 157 SmartCodes seeded
✓ API connects to database
✓ Automatic seeding on startup works
```

---

**Date Completed:** April 11, 2026  
**Docker Compose Version:** 3.8  
**PostgreSQL Version:** 17 Alpine  
**EF Core Version:** 10.0.5  
**Migration:** 20260411120850_InitialCreate
