using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Portal.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // User & Profile Management
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<SocialLink> SocialLinks { get; set; }
    public DbSet<WorkHistory> WorkHistories { get; set; }
    public DbSet<EducationHistory> EducationHistories { get; set; }
    public DbSet<WorkSample> WorkSamples { get; set; }
    public DbSet<EducationFocus> EducationFocuses { get; set; }
    public DbSet<MultiSelection> MultiSelections { get; set; }

    // Company & Organization
    public DbSet<CompanyProfile> CompanyProfiles { get; set; }
    public DbSet<CompanyClaim> CompanyClaims { get; set; }
    public DbSet<CompanyDocument> CompanyDocuments { get; set; }
    public DbSet<CompanyClaimMajor> CompanyClaimMajors { get; set; }
    public DbSet<CompanyClaimWorkAuthorization> CompanyClaimWorkAuthorizations { get; set; }
    public DbSet<CompanyMultiSelection> CompanyMultiSelections { get; set; }
    public DbSet<UserOrganization> UserOrganizations { get; set; }
    public DbSet<OrgUserConnection> OrgUserConnections { get; set; }

    // School & Career Center
    public DbSet<School> Schools { get; set; }
    public DbSet<SchoolClaim> SchoolClaims { get; set; }
    public DbSet<CareerCenterDocument> CareerCenterDocuments { get; set; }

    // Job Posts & Applications
    public DbSet<JobPost> JobPosts { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<JobApplicationAnswer> JobApplicationAnswers { get; set; }
    public DbSet<JobRequirement> JobRequirements { get; set; }
    public DbSet<JobRequirementGroup> JobRequirementGroups { get; set; }
    public DbSet<JobBenefit> JobBenefits { get; set; }
    public DbSet<ApplicationQuestion> ApplicationQuestions { get; set; }

    // Partnership & Billing
    public DbSet<PartnerPlan> PartnerPlans { get; set; }
    public DbSet<PartnershipSubscription> PartnershipSubscriptions { get; set; }
    public DbSet<PlanBenefit> PlanBenefits { get; set; }
    public DbSet<PlanBenefitType> PlanBenefitTypes { get; set; }
    public DbSet<PlanPrice> PlanPrices { get; set; }
    public DbSet<PlanContent> PlanContents { get; set; }
    public DbSet<PlanContentSection> PlanContentSections { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<AlaCarteItem> AlaCarteItems { get; set; }
    public DbSet<PlanBenefitAlaCarteItem> PlanBenefitAlaCarteItems { get; set; }
    public DbSet<ItemProcurement> ItemProcurements { get; set; }
    public DbSet<ItemRedemption> ItemRedemptions { get; set; }

    // Payment & Invoicing
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentAttempt> PaymentAttempts { get; set; }
    public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public DbSet<InvoiceDocument> InvoiceDocuments { get; set; }

    // User Connections & Interactions
    public DbSet<UserConnection> UserConnections { get; set; }
    public DbSet<UserConnectionChange> UserConnectionChanges { get; set; }
    public DbSet<UserBlock> UserBlocks { get; set; }
    public DbSet<UserFavorite> UserFavorites { get; set; }
    public DbSet<PotentialConnection> PotentialConnections { get; set; }

    // Reference Data
    public DbSet<SmartType> SmartTypes { get; set; }
    public DbSet<SmartCode> SmartCodes { get; set; }

    // Email & Communication
    public DbSet<EmailAction> EmailActions { get; set; }
    public DbSet<FileAttachment> FileAttachments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // UserProfile Configuration
        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(256);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Mobile).HasMaxLength(20);

            // Self-referencing relationships for UserConnection
            entity.HasMany(e => e.ApprovedConnections)
                .WithOne(e => e.Recipient)
                .HasForeignKey(e => e.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.InitiatedConnections)
                .WithOne(e => e.Requester)
                .HasForeignKey(e => e.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // CompanyProfile Configuration
        modelBuilder.Entity<CompanyProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
            entity.Property(e => e.WebsiteUrl).HasMaxLength(500);
            entity.Property(e => e.LogoUrl).HasMaxLength(500);

            entity.HasMany(e => e.JobPosts)
                .WithOne(e => e.CompanyProfile)
                .HasForeignKey(e => e.CompanyProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-one with ActiveClaim - configure as optional
            entity.HasOne(e => e.ActiveClaim)
                .WithOne()
                .HasForeignKey<CompanyProfile>("ActiveClaimId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // CompanyClaim Configuration
        modelBuilder.Entity<CompanyClaim>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Website).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.VideoUrl).HasMaxLength(500);
            entity.Property(e => e.AffinityGroupName).HasMaxLength(256);
            entity.Property(e => e.AffinityGroupWebsite).HasMaxLength(500);

            entity.HasOne(e => e.CompanyProfile)
                .WithMany()
                .HasForeignKey(e => e.CompanyProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.UserProfile)
                .WithMany(u => u.CompanyClaims)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.Address)
                .WithMany()
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.CurrentSubscription)
                .WithMany()
                .HasForeignKey(e => e.CurrentSubscriptionId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // School Configuration
        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
            entity.Property(e => e.UniversityName).HasMaxLength(256);
            entity.Property(e => e.CollegeName).HasMaxLength(256);
            entity.Property(e => e.ZipCode).HasMaxLength(10);
            entity.Property(e => e.DisplayName).HasMaxLength(512);

            entity.HasOne(e => e.ActiveClaim)
                .WithOne()
                .HasForeignKey<School>("ActiveClaimId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // SchoolClaim Configuration
        modelBuilder.Entity<SchoolClaim>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // JobPost Configuration
        modelBuilder.Entity<JobPost>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.JobTitle).IsRequired().HasMaxLength(256);
            entity.Property(e => e.JobLocation).HasMaxLength(256);
            entity.Property(e => e.MinCompensation).HasColumnType("decimal(18,2)");
            entity.Property(e => e.MaxCompensation).HasColumnType("decimal(18,2)");
            entity.Property(e => e.CompensationDetails).HasMaxLength(500);
            entity.Property(e => e.SalaryOffered).HasMaxLength(100);
            entity.Property(e => e.ApplyUrl).HasMaxLength(500);

            entity.HasOne(e => e.CompanyProfile)
                .WithMany(c => c.JobPosts)
                .HasForeignKey(e => e.CompanyProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Company)
                .WithMany(c => c.JobPosts)
                .HasForeignKey("CompanyClaimId")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.AssignedRecruiter)
                .WithMany()
                .HasForeignKey("AssignedRecruiterId")
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(e => e.Applications)
                .WithOne(a => a.JobPost)
                .HasForeignKey(a => a.JobPostId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // JobApplication Configuration
        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.JobPost)
                .WithMany(j => j.Applications)
                .HasForeignKey(e => e.JobPostId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Applicant)
                .WithMany(u => u.JobApplications)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // JobApplicationAnswer Configuration
        modelBuilder.Entity<JobApplicationAnswer>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // JobRequirement Configuration
        modelBuilder.Entity<JobRequirement>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.JobPost)
                .WithMany(j => j.Requirements)
                .HasForeignKey(e => e.JobPostId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // UserConnection Configuration
        modelBuilder.Entity<UserConnection>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(e => e.Requester)
                .WithMany(u => u.InitiatedConnections)
                .HasForeignKey(e => e.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Recipient)
                .WithMany(u => u.ApprovedConnections)
                .HasForeignKey(e => e.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Approver)
                .WithMany()
                .HasForeignKey("ApproverId")
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.Initiator)
                .WithMany()
                .HasForeignKey("InitiatorId")
                .OnDelete(DeleteBehavior.SetNull);
        });

        // UserBlock Configuration
        modelBuilder.Entity<UserBlock>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Blocker)
                .WithMany(u => u.Blocks)
                .HasForeignKey(e => e.BlockerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Blocked)
                .WithMany()
                .HasForeignKey(e => e.BlockedId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // PartnerPlan Configuration
        modelBuilder.Entity<PartnerPlan>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18,2)");
        });

        // PartnershipSubscription Configuration
        modelBuilder.Entity<PartnershipSubscription>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.CompanyProfile)
                .WithMany()
                .HasForeignKey(e => e.CompanyProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Plan)
                .WithMany()
                .HasForeignKey(e => e.PartnerPlanId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // PaymentMethod Configuration
        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MaskedDetails).HasMaxLength(100);
            entity.Property(e => e.StripeId).HasMaxLength(256);
        });

        // InvoiceHeader Configuration
        modelBuilder.Entity<InvoiceHeader>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // InvoiceDetail Configuration
        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
        });

        // Discount Configuration
        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
        });

        // SmartType Configuration
        modelBuilder.Entity<SmartType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Category).HasMaxLength(100);
        });

        // SmartCode Configuration
        modelBuilder.Entity<SmartCode>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Value).IsRequired().HasMaxLength(256);
            entity.Property(e => e.Label).IsRequired().HasMaxLength(256);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.HasOne(e => e.SmartType)
                .WithMany(t => t.SmartCodes)
                .HasForeignKey(e => e.SmartTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => new { e.SmartTypeId, e.Code }).IsUnique();
        });

        // Address Configuration
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Line1).HasMaxLength(256);
            entity.Property(e => e.Line2).HasMaxLength(256);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasMaxLength(20);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.Country).HasMaxLength(100);
        });

        // SocialLink Configuration
        modelBuilder.Entity<SocialLink>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Url).HasMaxLength(500);
        });

        // WorkHistory Configuration
        modelBuilder.Entity<WorkHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.JobTitle).HasMaxLength(256);
            entity.Property(e => e.CompanyName).HasMaxLength(256);

            entity.HasOne(e => e.UserProfile)
                .WithMany(u => u.WorkHistories)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Company and CareerCenter are optional references without FK properties
            entity.HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey("CompanyProfileId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.CareerCenter)
                .WithMany()
                .HasForeignKey("SchoolId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // EducationHistory Configuration
        modelBuilder.Entity<EducationHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Degree).HasMaxLength(256);
            entity.Property(e => e.Major).HasMaxLength(256);
            entity.Property(e => e.SchoolName).HasMaxLength(256);
            entity.Property(e => e.GradePointAverage).HasColumnType("decimal(3,2)");

            entity.HasOne(e => e.UserProfile)
                .WithMany(u => u.EducationHistories)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Majors and Minors - ignore for now (likely need join tables)
            entity.Ignore(e => e.Majors);
            entity.Ignore(e => e.Minors);
        });

        // WorkSample Configuration
        modelBuilder.Entity<WorkSample>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).HasMaxLength(256);
            entity.Property(e => e.Url).HasMaxLength(500);

            entity.HasOne(e => e.UserProfile)
                .WithMany(u => u.WorkSamples)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // MultiSelection Configuration
        modelBuilder.Entity<MultiSelection>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // UserOrganization Configuration
        modelBuilder.Entity<UserOrganization>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.UserProfile)
                .WithMany(u => u.Organizations)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // JobRequirementGroup Configuration
        modelBuilder.Entity<JobRequirementGroup>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        // JobBenefit Configuration
        modelBuilder.Entity<JobBenefit>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        // ApplicationQuestion Configuration
        modelBuilder.Entity<ApplicationQuestion>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Question).HasMaxLength(1000);
        });

        // PlanBenefit Configuration
        modelBuilder.Entity<PlanBenefit>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // PlanBenefitType Configuration
        modelBuilder.Entity<PlanBenefitType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        // PlanPrice Configuration
        modelBuilder.Entity<PlanPrice>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });

        // UserFavorite Configuration
        modelBuilder.Entity<UserFavorite>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // EmailAction Configuration
        modelBuilder.Entity<EmailAction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Template).IsRequired().HasMaxLength(500);
        });

        // FileAttachment Configuration
        modelBuilder.Entity<FileAttachment>(entity =>
        {
            entity.HasNoKey();
            entity.Property(e => e.FileName).HasMaxLength(256);
        });

        // CompanyDocument Configuration
        modelBuilder.Entity<CompanyDocument>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // CareerCenterDocument Configuration
        modelBuilder.Entity<CareerCenterDocument>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // CompanyClaimMajor Configuration
        modelBuilder.Entity<CompanyClaimMajor>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // CompanyClaimWorkAuthorization Configuration
        modelBuilder.Entity<CompanyClaimWorkAuthorization>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // CompanyMultiSelection Configuration
        modelBuilder.Entity<CompanyMultiSelection>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.SmartCode)
                .WithMany()
                .HasForeignKey(e => e.SmartCodeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Value is the same as SmartCode - ignore it to avoid ambiguity
            entity.Ignore(e => e.Value);
        });

        // OrgUserConnection Configuration
        modelBuilder.Entity<OrgUserConnection>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // PotentialConnection Configuration
        modelBuilder.Entity<PotentialConnection>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.UserProfile)
                .WithMany()
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.TargetUserProfile)
                .WithMany()
                .HasForeignKey(e => e.TargetUserProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            // Match is redundant - ignore it
            entity.Ignore(e => e.Match);
        });

        // UserConnectionChange Configuration
        modelBuilder.Entity<UserConnectionChange>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // PaymentAttempt Configuration
        modelBuilder.Entity<PaymentAttempt>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
        });

        // InvoiceDocument Configuration
        modelBuilder.Entity<InvoiceDocument>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // AlaCarteItem Configuration
        modelBuilder.Entity<AlaCarteItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });

        // PlanBenefitAlaCarteItem Configuration
        modelBuilder.Entity<PlanBenefitAlaCarteItem>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // ItemProcurement Configuration
        modelBuilder.Entity<ItemProcurement>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // ItemRedemption Configuration
        modelBuilder.Entity<ItemRedemption>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // PlanContent Configuration
        modelBuilder.Entity<PlanContent>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // PlanContentSection Configuration
        modelBuilder.Entity<PlanContentSection>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
        });

        // EducationFocus Configuration
        modelBuilder.Entity<EducationFocus>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(256);
        });
    }
}
