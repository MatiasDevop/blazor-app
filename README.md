# CPCC Campus App - Quick Start Guide

## ✅ What's Completed

### Task 1: EF Core PostgreSQL Setup

- ✅ All 52 domain entities configured with EF Core
- ✅ ApplicationDbContext created with proper relationships
- ✅ Connection resilience configured
- ✅ Project builds successfully
- 📄 [Full Documentation](TASK1_EF_CORE_SETUP.md)

### Task 2: Docker + Database Setup

- ✅ Docker Compose configured for PostgreSQL
- ✅ Database schema created (53 tables)
- ✅ Initial migration applied
- ✅ 10 SmartTypes + 157 SmartCodes seeded
- ✅ pgAdmin included for database management
- ✅ Automatic seeding on API startup
- 📄 [Full Documentation](DOCKER_DATABASE_SETUP.md)

---

## 🚀 Quick Start (5 Minutes)

### Prerequisites

- .NET 10 SDK installed
- Docker Desktop installed and running

### 1. Start the Database

```bash
# Option A: Using helper script (recommended)
./db.sh start

# Option B: Using docker-compose directly
docker-compose up -d postgres
```

### 2. Run the API

```bash
cd Portal.Api
dotnet run
```

The API will:

- Apply any pending migrations
- Seed reference data (SmartTypes/SmartCodes)
- Start listening on `http://localhost:5130`

### 3. Verify Setup

```bash
# Check database tables
./db.sh tables

# Count seeded records
./db.sh count

# Connect to database
./db.sh psql
```

---

## 📊 Database Management

### Using the Helper Script (`db.sh`)

```bash
./db.sh start       # Start PostgreSQL
./db.sh stop        # Stop all services
./db.sh logs        # View logs
./db.sh psql        # Connect to database CLI
./db.sh tables      # List all tables
./db.sh count       # Count records
./db.sh backup      # Create backup
./db.sh help        # See all commands
```

### Using pgAdmin (Visual Management)

1. Start pgAdmin: `./db.sh start-all`
2. Open browser: http://localhost:5050
3. Login: `admin@cpcc.local` / `admin`
4. Add server connection:
   - Host: `postgres`
   - Port: `5432`
   - Database: `cpcc_campus_app_dev`
   - Username: `postgres`
   - Password: `postgres`

---

## 📁 Project Structure

```
blazor-app/
├── Portal.Api/                    # ASP.NET Core API (5% complete)
│   ├── Data/
│   │   ├── ApplicationDbContext.cs    # EF Core DbContext (52 entities)
│   │   └── Seeds/
│   │       └── SmartTypesSeeder.cs    # Reference data seeding
│   ├── Migrations/                    # EF Core migrations
│   └── Program.cs                     # Startup + auto-seeding
├── Portal.Blazor/                 # Blazor WebAssembly (85% complete)
├── Domain/                        # 52 entity classes
├── ViewModels/                    # CQRS commands/queries/DTOs
├── Constants/                     # App-wide constants
├── Enums/                         # Shared enumerations
├── Mappings/                      # AutoMapper profiles
├── Validations/                   # FluentValidation rules
├── docker-compose.yml             # Docker services configuration
├── .env                           # Environment variables (git-ignored)
├── db.sh                          # Database helper script
├── DOCKER_DATABASE_SETUP.md       # Docker setup documentation
└── TASK1_EF_CORE_SETUP.md        # EF Core implementation details
```

---

## 🗄️ Database Status

**Tables Created:** 53  
**Reference Types:** 10 SmartTypes  
**Reference Data:** 157 SmartCodes

### SmartTypes Available:

1. **State** - 51 US states/territories
2. **GenderIdentity** - 10 gender options
3. **SexualOrientation** - 10 orientation options
4. **PrimaryLanguage** - 16 languages
5. **RaceEthnicity** - 9 race/ethnicity options
6. **Pronouns** - 7 pronoun sets
7. **OrganizationSize** - 8 company size ranges
8. **Industry** - 19 industry categories
9. **DegreeLevel** - 9 education levels
10. **Skills** - 18 professional skills

---

## 🔧 Common Tasks

### Create a New Migration

```bash
cd Portal.Api
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Reset Database (Fresh Start)

```bash
./db.sh reset
```

### View Recent Logs

```bash
./db.sh logs
```

### Check What's Running

```bash
./db.sh status
```

### Backup Database

```bash
./db.sh backup
# Creates: backup_YYYYMMDD_HHMMSS.sql
```

### Restore Database

```bash
./db.sh restore backup_20260411_120000.sql
```

---

## 🎯 Next Steps (Priority Order)

### Task 3: Implement MediatR Handlers ⏭️

- Create handlers for 22 existing commands
- Expand query layer (currently only 4 queries)
- Wire up handlers in API

### Task 4: Build API Controllers ⏭️

- UserProfileController
- JobPostController
- CompanyController
- MatchingController
- SearchController
- RegistrationController

### Task 5: Add Authentication ⏭️

- Configure Auth0 JWT bearer validation in API
- Map Auth0 claims to UserProfile
- Implement authorization policies

### Task 6: Connect Frontend to API ⏭️

- Update Blazor API URL configuration
- Test all 27 frontend services against real endpoints
- Handle authentication tokens

---

## 🔗 External Services Configuration

The app integrates with several external services (configured in `Portal.Blazor/wwwroot/appsettings.json`):

- **Auth0**: Authentication provider
- **Stripe**: Payment processing (test keys)
- **Weavy**: Chat/messaging platform
- **Google reCAPTCHA v3**: Form protection
- **MailerSend**: Email delivery

---

## 🐛 Troubleshooting

### Database Won't Start

```bash
docker-compose logs postgres
docker-compose restart postgres
```

### Migration Fails

```bash
cd Portal.Api
dotnet clean && dotnet build
dotnet ef database update
```

### Can't Connect to Database

```bash
# Test connection
docker exec cpcc_postgres pg_isready -U postgres

# Check container is running
docker ps | grep cpcc_postgres
```

### Seed Data Not Loading

Database already seeded. The seeder checks for existing data. To re-seed:

```bash
./db.sh reset
cd Portal.Api && dotnet run
```

---

## 📊 Build Status

| Component       | Status     | Notes                                        |
| --------------- | ---------- | -------------------------------------------- |
| Portal.Api      | ✅ Builds  | 0 errors, 344 nullable warnings (ViewModels) |
| Portal.Blazor   | ✅ Builds  | Frontend complete (~85%)                     |
| PostgreSQL      | ✅ Running | Docker container healthy                     |
| Database Schema | ✅ Created | 53 tables                                    |
| Reference Data  | ✅ Seeded  | 10 types, 157 codes                          |
| Migrations      | ✅ Applied | InitialCreate complete                       |

---

## 🌐 Ports in Use

| Service       | Port | URL                   |
| ------------- | ---- | --------------------- |
| Portal.Api    | 5130 | http://localhost:5130 |
| Portal.Blazor | 5085 | http://localhost:5085 |
| PostgreSQL    | 5432 | localhost:5432        |
| pgAdmin       | 5050 | http://localhost:5050 |

---

## 📚 Documentation

- [TASK1_EF_CORE_SETUP.md](TASK1_EF_CORE_SETUP.md) - EF Core implementation details
- [DOCKER_DATABASE_SETUP.md](DOCKER_DATABASE_SETUP.md) - Docker and database setup
- [docker-compose.yml](docker-compose.yml) - Docker services configuration
- [.env.example](.env.example) - Environment variables template

---

## ✨ Key Technical Decisions

1. **Docker for PostgreSQL** - Consistent dev environment, easy setup/teardown
2. **Automatic Seeding** - Reference data loads on first API startup
3. **Separate Dev Database** - `cpcc_campus_app_dev` prevents prod accidents
4. **Connection Resilience** - 5 retry attempts for transient failures
5. **Helper Script** - `db.sh` for common database tasks
6. **pgAdmin Included** - Visual database management out of the box

---

**Last Updated:** April 11, 2026  
**Database Version:** PostgreSQL 17 Alpine  
**Migration:** 20260411120850_InitialCreate  
**Status:** ✅ Ready for API Development
