using Enums;

namespace Domain.Entities
{
    public class CompanyClaim
    {
        public Guid Id { get; set; }

        // Relationships
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; } = null!;

        public Guid? UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public Guid? OrganizationSizeId { get; set; }
        public SmartCode? OrganizationSize { get; set; }

        public Guid? CurrentSubscriptionId { get; set; }
        public PartnershipSubscription? CurrentSubscription { get; set; }

        // Scalars
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? AffinityGroupName { get; set; }
        public string? AffinityGroupDescription { get; set; }
        public string? AffinityGroupWebsite { get; set; }
        public WorkAuthorizationType WorkAuthorization { get; set; }
        public string? WorkAuthorizationOther { get; set; }
        public ClaimStatus Status { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DatePaymentReceived { get; set; }

        // Collections
        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
        public ICollection<InvoiceHeader> Invoices { get; set; } = new List<InvoiceHeader>();
        public ICollection<CompanyMultiSelection> MultiSelections { get; set; } = new List<CompanyMultiSelection>();
        public ICollection<CompanyClaimMajor> Majors { get; set; } = new List<CompanyClaimMajor>();
        public ICollection<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
        public ICollection<CompanyDocument> Documents { get; set; } = new List<CompanyDocument>();
        public ICollection<PartnershipSubscription> Subscriptions { get; set; } = new List<PartnershipSubscription>();
        public ICollection<OrgUserConnection> UserConnections { get; set; } = new List<OrgUserConnection>();
        public ICollection<CompanyClaimWorkAuthorization> AcceptedWorkAuthorizations { get; set; } = new List<CompanyClaimWorkAuthorization>();
        public ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
        public ICollection<ItemProcurement> ItemProcurements { get; set; } = new List<ItemProcurement>();

        // Logo storage strategy (URL or blob). XPO used FileData; choose one.
        public string? LogoUrl { get; set; }
        public byte[]? LogoBytes { get; set; }

        // Helper computed (not mapped by default). EF: project in queries rather than persist.
        // public bool Active => CompanyProfile?.ActiveClaimId == Id; // implement via query/projection
    }
}
