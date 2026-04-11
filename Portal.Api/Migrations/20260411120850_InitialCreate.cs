using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlaCarteItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    AllowMultiple = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    DisplayGroup = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Availability = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlaCarteItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    FileName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Content = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PartnerPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BasePrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanBenefitTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanBenefitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmartTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsPercentage = table.Column<bool>(type: "boolean", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TargetPlanId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_PartnerPlans_TargetPlanId",
                        column: x => x.TargetPlanId,
                        principalTable: "PartnerPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanBenefits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanBenefits_PartnerPlans_PartnerPlanId",
                        column: x => x.PartnerPlanId,
                        principalTable: "PartnerPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanContents_PartnerPlans_PartnerPlanId",
                        column: x => x.PartnerPlanId,
                        principalTable: "PartnerPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Interval = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ForRenewOnly = table.Column<bool>(type: "boolean", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPrices_PartnerPlans_PartnerPlanId",
                        column: x => x.PartnerPlanId,
                        principalTable: "PartnerPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmartCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Label = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsCustom = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartCodes_SmartTypes_SmartTypeId",
                        column: x => x.SmartTypeId,
                        principalTable: "SmartTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanBenefitAlaCarteItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanBenefitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanBenefitAlaCarteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanBenefitAlaCarteItems_PlanBenefits_PlanBenefitId",
                        column: x => x.PlanBenefitId,
                        principalTable: "PlanBenefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanContentSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanContentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanContentSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanContentSections_PlanContents_PlanContentId",
                        column: x => x.PlanContentId,
                        principalTable: "PlanContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProfileType = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Mobile = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    GenderIdentityId = table.Column<Guid>(type: "uuid", nullable: false),
                    SexualIdentityId = table.Column<Guid>(type: "uuid", nullable: false),
                    PrimaryLanguageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_SmartCodes_GenderIdentityId",
                        column: x => x.GenderIdentityId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_SmartCodes_PrimaryLanguageId",
                        column: x => x.PrimaryLanguageId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_SmartCodes_SexualIdentityId",
                        column: x => x.SexualIdentityId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Line1 = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Line2 = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    StateId = table.Column<Guid>(type: "uuid", nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_SmartCodes_StateId",
                        column: x => x.StateId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Degree = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Major = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GraduationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GradePointAverage = table.Column<decimal>(type: "numeric(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationHistories_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Template = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailActions_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MultiSelections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartCodeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiSelections_SmartCodes_SmartCodeId",
                        column: x => x.SmartCodeId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiSelections_SmartTypes_SmartTypeId",
                        column: x => x.SmartTypeId,
                        principalTable: "SmartTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiSelections_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PotentialConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetUserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotentialConnections_UserProfiles_TargetUserProfileId",
                        column: x => x.TargetUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PotentialConnections_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockedId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    ReportOnly = table.Column<bool>(type: "boolean", nullable: false),
                    DateUnblocked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBlocks_UserProfiles_BlockedId",
                        column: x => x.BlockedId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBlocks_UserProfiles_BlockerId",
                        column: x => x.BlockerId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DateApproved = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ApproverId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitiatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserConnections_UserProfiles_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserConnections_UserProfiles_InitiatorId",
                        column: x => x.InitiatorId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserConnections_UserProfiles_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserConnections_UserProfiles_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkSamples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSamples_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConnectionChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserConnectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangeType = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConnectionChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserConnectionChanges_UserConnections_UserConnectionId",
                        column: x => x.UserConnectionId,
                        principalTable: "UserConnections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Question = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CareerCenterDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    File = table.Column<byte[]>(type: "bytea", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SchoolClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerCenterDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyClaimMajors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartCodeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EducationFocusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyClaimMajors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyClaimMajors_SmartCodes_SmartCodeId",
                        column: x => x.SmartCodeId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrganizationSizeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CurrentSubscriptionId = table.Column<Guid>(type: "uuid", nullable: true),
                    Website = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    VideoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AffinityGroupName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    AffinityGroupDescription = table.Column<string>(type: "text", nullable: true),
                    AffinityGroupWebsite = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    WorkAuthorization = table.Column<int>(type: "integer", nullable: false),
                    WorkAuthorizationOther = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateApproved = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DatePaymentReceived = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    LogoBytes = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyClaims_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CompanyClaims_SmartCodes_OrganizationSizeId",
                        column: x => x.OrganizationSizeId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyClaims_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CompanyClaimWorkAuthorizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartCodeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyClaimWorkAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyClaimWorkAuthorizations_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyClaimWorkAuthorizations_SmartCodes_SmartCodeId",
                        column: x => x.SmartCodeId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LogoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActiveClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfiles_CompanyClaims_ActiveClaimId",
                        column: x => x.ActiveClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMultiSelections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartCodeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Field = table.Column<string>(type: "text", nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMultiSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyMultiSelections_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyMultiSelections_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMultiSelections_SmartCodes_SmartCodeId",
                        column: x => x.SmartCodeId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyMultiSelections_SmartTypes_SmartTypeId",
                        column: x => x.SmartTypeId,
                        principalTable: "SmartTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaders_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceHeaders_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemProcurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProcurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemProcurements_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemProcurements_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemRedemptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    RedeemedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRedemptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRedemptions_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobTitle = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    JobLocation = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    MinCompensation = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    MaxCompensation = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CompensationDetails = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    SalaryOffered = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UseCpccApplyNow = table.Column<bool>(type: "boolean", nullable: false),
                    ApplyUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssignedRecruiterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosts_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobPosts_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPosts_UserProfiles_AssignedRecruiterId",
                        column: x => x.AssignedRecruiterId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaskedDetails = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    NameOnCard = table.Column<string>(type: "text", nullable: false),
                    MaskedAccount = table.Column<string>(type: "text", nullable: false),
                    ExpirationMonth = table.Column<short>(type: "smallint", nullable: false),
                    ExpirationYear = table.Column<short>(type: "smallint", nullable: false),
                    StripeId = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentMethods_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrganizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAccounting = table.Column<bool>(type: "boolean", nullable: false),
                    IsBilling = table.Column<bool>(type: "boolean", nullable: false),
                    IsClaimHolder = table.Column<bool>(type: "boolean", nullable: false),
                    IsEventsManager = table.Column<bool>(type: "boolean", nullable: false),
                    IsUserManager = table.Column<bool>(type: "boolean", nullable: false),
                    IsRecruiter = table.Column<bool>(type: "boolean", nullable: false),
                    IsTechnical = table.Column<bool>(type: "boolean", nullable: false),
                    IsAccountOwner = table.Column<bool>(type: "boolean", nullable: false),
                    IsJobManager = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrganizations_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrganizations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "InvoiceHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDocuments_InvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "InvoiceHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uuid", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentAttempts_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentAttempts_InvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "InvoiceHeaders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppliedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DateApplied = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateReviewed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CoverLetter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobBenefits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobBenefits_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirementGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirementGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRequirementGroups_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavorites_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplicationAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobApplicationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplicationAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplicationAnswers_ApplicationQuestions_ApplicationQuest~",
                        column: x => x.ApplicationQuestionId,
                        principalTable: "ApplicationQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplicationAnswers_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRequirements_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobRequirements_JobRequirementGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "JobRequirementGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationFocuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsCustom = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationFocuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgUserConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgUserConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgUserConnections_CompanyClaims_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgUserConnections_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgUserConnections_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartnershipSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: true),
                    SchoolClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnershipSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnershipSubscriptions_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartnershipSubscriptions_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnershipSubscriptions_PartnerPlans_PartnerPlanId",
                        column: x => x.PartnerPlanId,
                        principalTable: "PartnerPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<byte[]>(type: "bytea", nullable: false),
                    InstitutionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationSizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerCenterName = table.Column<string>(type: "text", nullable: false),
                    WhoWeAre = table.Column<string>(type: "text", nullable: false),
                    VideoUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClaims_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClaims_SmartCodes_InstitutionTypeId",
                        column: x => x.InstitutionTypeId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClaims_SmartCodes_OrganizationSizeId",
                        column: x => x.OrganizationSizeId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClaims_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StateId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActiveClaimId = table.Column<Guid>(type: "uuid", nullable: true),
                    UniversityName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CollegeName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_SchoolClaims_ActiveClaimId",
                        column: x => x.ActiveClaimId,
                        principalTable: "SchoolClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schools_SmartCodes_StateId",
                        column: x => x.StateId,
                        principalTable: "SmartCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Platform = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CompanyClaimId = table.Column<Guid>(type: "uuid", nullable: true),
                    SchoolClaimId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLinks_CompanyClaims_CompanyClaimId",
                        column: x => x.CompanyClaimId,
                        principalTable: "CompanyClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialLinks_SchoolClaims_SchoolClaimId",
                        column: x => x.SchoolClaimId,
                        principalTable: "SchoolClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialLinks_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    JobTitle = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CompanyProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHistories_CompanyProfiles_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WorkHistories_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WorkHistories_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserProfileId",
                table: "Addresses",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestions_JobPostId",
                table: "ApplicationQuestions",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CareerCenterDocuments_SchoolClaimId",
                table: "CareerCenterDocuments",
                column: "SchoolClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CareerCenterDocuments_SchoolId",
                table: "CareerCenterDocuments",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaimMajors_CompanyClaimId",
                table: "CompanyClaimMajors",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaimMajors_EducationFocusId",
                table: "CompanyClaimMajors",
                column: "EducationFocusId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaimMajors_SmartCodeId",
                table: "CompanyClaimMajors",
                column: "SmartCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaims_AddressId",
                table: "CompanyClaims",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaims_CompanyProfileId",
                table: "CompanyClaims",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaims_CurrentSubscriptionId",
                table: "CompanyClaims",
                column: "CurrentSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaims_OrganizationSizeId",
                table: "CompanyClaims",
                column: "OrganizationSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaims_UserProfileId",
                table: "CompanyClaims",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaimWorkAuthorizations_CompanyClaimId",
                table: "CompanyClaimWorkAuthorizations",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaimWorkAuthorizations_SmartCodeId",
                table: "CompanyClaimWorkAuthorizations",
                column: "SmartCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_CompanyClaimId",
                table: "CompanyDocuments",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_CompanyProfileId",
                table: "CompanyDocuments",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMultiSelections_CompanyClaimId",
                table: "CompanyMultiSelections",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMultiSelections_CompanyProfileId",
                table: "CompanyMultiSelections",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMultiSelections_SmartCodeId",
                table: "CompanyMultiSelections",
                column: "SmartCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMultiSelections_SmartTypeId",
                table: "CompanyMultiSelections",
                column: "SmartTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_ActiveClaimId",
                table: "CompanyProfiles",
                column: "ActiveClaimId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_Code",
                table: "Discounts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_TargetPlanId",
                table: "Discounts",
                column: "TargetPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationFocuses_SchoolId",
                table: "EducationFocuses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationHistories_UserProfileId",
                table: "EducationHistories",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailActions_UserProfileId",
                table: "EmailActions",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderId",
                table: "InvoiceDetails",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocuments_InvoiceHeaderId",
                table: "InvoiceDocuments",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_CompanyClaimId",
                table: "InvoiceHeaders",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_CompanyProfileId",
                table: "InvoiceHeaders",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemProcurements_CompanyClaimId",
                table: "ItemProcurements",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemProcurements_CompanyProfileId",
                table: "ItemProcurements",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRedemptions_CompanyProfileId",
                table: "ItemRedemptions",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplicationAnswers_ApplicationQuestionId",
                table: "JobApplicationAnswers",
                column: "ApplicationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplicationAnswers_JobApplicationId",
                table: "JobApplicationAnswers",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobPostId",
                table: "JobApplications",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserProfileId",
                table: "JobApplications",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBenefits_JobPostId",
                table: "JobBenefits",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_AssignedRecruiterId",
                table: "JobPosts",
                column: "AssignedRecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CompanyClaimId",
                table: "JobPosts",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CompanyProfileId",
                table: "JobPosts",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirementGroups_JobPostId",
                table: "JobRequirementGroups",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirements_GroupId",
                table: "JobRequirements",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirements_JobPostId",
                table: "JobRequirements",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiSelections_SmartCodeId",
                table: "MultiSelections",
                column: "SmartCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiSelections_SmartTypeId",
                table: "MultiSelections",
                column: "SmartTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiSelections_UserProfileId",
                table: "MultiSelections",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUserConnections_CompanyId",
                table: "OrgUserConnections",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUserConnections_CompanyProfileId",
                table: "OrgUserConnections",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUserConnections_SchoolId",
                table: "OrgUserConnections",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUserConnections_UserProfileId",
                table: "OrgUserConnections",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnershipSubscriptions_CompanyClaimId",
                table: "PartnershipSubscriptions",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnershipSubscriptions_CompanyProfileId",
                table: "PartnershipSubscriptions",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnershipSubscriptions_PartnerPlanId",
                table: "PartnershipSubscriptions",
                column: "PartnerPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnershipSubscriptions_SchoolClaimId",
                table: "PartnershipSubscriptions",
                column: "SchoolClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAttempts_CompanyProfileId",
                table: "PaymentAttempts",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAttempts_InvoiceHeaderId",
                table: "PaymentAttempts",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CompanyClaimId",
                table: "PaymentMethods",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CompanyProfileId",
                table: "PaymentMethods",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanBenefitAlaCarteItems_PlanBenefitId",
                table: "PlanBenefitAlaCarteItems",
                column: "PlanBenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanBenefits_PartnerPlanId",
                table: "PlanBenefits",
                column: "PartnerPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanContents_PartnerPlanId",
                table: "PlanContents",
                column: "PartnerPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanContentSections_PlanContentId",
                table: "PlanContentSections",
                column: "PlanContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPrices_PartnerPlanId",
                table: "PlanPrices",
                column: "PartnerPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialConnections_TargetUserProfileId",
                table: "PotentialConnections",
                column: "TargetUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialConnections_UserProfileId",
                table: "PotentialConnections",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClaims_AddressId",
                table: "SchoolClaims",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClaims_InstitutionTypeId",
                table: "SchoolClaims",
                column: "InstitutionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClaims_OrganizationSizeId",
                table: "SchoolClaims",
                column: "OrganizationSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClaims_SchoolId",
                table: "SchoolClaims",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClaims_UserProfileId",
                table: "SchoolClaims",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_ActiveClaimId",
                table: "Schools",
                column: "ActiveClaimId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_StateId",
                table: "Schools",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartCodes_SmartTypeId_Code",
                table: "SmartCodes",
                columns: new[] { "SmartTypeId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmartTypes_Name",
                table: "SmartTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_CompanyClaimId",
                table: "SocialLinks",
                column: "CompanyClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_SchoolClaimId",
                table: "SocialLinks",
                column: "SchoolClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_UserProfileId",
                table: "SocialLinks",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlocks_BlockedId",
                table: "UserBlocks",
                column: "BlockedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlocks_BlockerId",
                table: "UserBlocks",
                column: "BlockerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConnectionChanges_UserConnectionId",
                table: "UserConnectionChanges",
                column: "UserConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConnections_ApproverId",
                table: "UserConnections",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConnections_InitiatorId",
                table: "UserConnections",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConnections_RecipientId",
                table: "UserConnections",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConnections_RequesterId",
                table: "UserConnections",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_JobPostId",
                table: "UserFavorites",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_UserProfileId",
                table: "UserFavorites",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_CompanyProfileId",
                table: "UserOrganizations",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_UserProfileId",
                table: "UserOrganizations",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_Email",
                table: "UserProfiles",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_GenderIdentityId",
                table: "UserProfiles",
                column: "GenderIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_PrimaryLanguageId",
                table: "UserProfiles",
                column: "PrimaryLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_SexualIdentityId",
                table: "UserProfiles",
                column: "SexualIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_CompanyProfileId",
                table: "WorkHistories",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_SchoolId",
                table: "WorkHistories",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_UserProfileId",
                table: "WorkHistories",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSamples_UserProfileId",
                table: "WorkSamples",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationQuestions_JobPosts_JobPostId",
                table: "ApplicationQuestions",
                column: "JobPostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CareerCenterDocuments_SchoolClaims_SchoolClaimId",
                table: "CareerCenterDocuments",
                column: "SchoolClaimId",
                principalTable: "SchoolClaims",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerCenterDocuments_Schools_SchoolId",
                table: "CareerCenterDocuments",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaimMajors_CompanyClaims_CompanyClaimId",
                table: "CompanyClaimMajors",
                column: "CompanyClaimId",
                principalTable: "CompanyClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaimMajors_EducationFocuses_EducationFocusId",
                table: "CompanyClaimMajors",
                column: "EducationFocusId",
                principalTable: "EducationFocuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaims_CompanyProfiles_CompanyProfileId",
                table: "CompanyClaims",
                column: "CompanyProfileId",
                principalTable: "CompanyProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaims_PartnershipSubscriptions_CurrentSubscriptionId",
                table: "CompanyClaims",
                column: "CurrentSubscriptionId",
                principalTable: "PartnershipSubscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationFocuses_Schools_SchoolId",
                table: "EducationFocuses",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrgUserConnections_SchoolClaims_SchoolId",
                table: "OrgUserConnections",
                column: "SchoolId",
                principalTable: "SchoolClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartnershipSubscriptions_SchoolClaims_SchoolClaimId",
                table: "PartnershipSubscriptions",
                column: "SchoolClaimId",
                principalTable: "SchoolClaims",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClaims_Schools_SchoolId",
                table: "SchoolClaims",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_SmartCodes_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyClaims_SmartCodes_OrganizationSizeId",
                table: "CompanyClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClaims_SmartCodes_InstitutionTypeId",
                table: "SchoolClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClaims_SmartCodes_OrganizationSizeId",
                table: "SchoolClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SmartCodes_StateId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_GenderIdentityId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_PrimaryLanguageId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_SexualIdentityId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyClaims_UserProfiles_UserProfileId",
                table: "CompanyClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClaims_UserProfiles_UserProfileId",
                table: "SchoolClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_PartnershipSubscriptions_SchoolClaims_SchoolClaimId",
                table: "PartnershipSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SchoolClaims_ActiveClaimId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProfiles_CompanyClaims_ActiveClaimId",
                table: "CompanyProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PartnershipSubscriptions_CompanyClaims_CompanyClaimId",
                table: "PartnershipSubscriptions");

            migrationBuilder.DropTable(
                name: "AlaCarteItems");

            migrationBuilder.DropTable(
                name: "CareerCenterDocuments");

            migrationBuilder.DropTable(
                name: "CompanyClaimMajors");

            migrationBuilder.DropTable(
                name: "CompanyClaimWorkAuthorizations");

            migrationBuilder.DropTable(
                name: "CompanyDocuments");

            migrationBuilder.DropTable(
                name: "CompanyMultiSelections");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "EducationHistories");

            migrationBuilder.DropTable(
                name: "EmailActions");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "InvoiceDocuments");

            migrationBuilder.DropTable(
                name: "ItemProcurements");

            migrationBuilder.DropTable(
                name: "ItemRedemptions");

            migrationBuilder.DropTable(
                name: "JobApplicationAnswers");

            migrationBuilder.DropTable(
                name: "JobBenefits");

            migrationBuilder.DropTable(
                name: "JobRequirements");

            migrationBuilder.DropTable(
                name: "MultiSelections");

            migrationBuilder.DropTable(
                name: "OrgUserConnections");

            migrationBuilder.DropTable(
                name: "PaymentAttempts");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PlanBenefitAlaCarteItems");

            migrationBuilder.DropTable(
                name: "PlanBenefitTypes");

            migrationBuilder.DropTable(
                name: "PlanContentSections");

            migrationBuilder.DropTable(
                name: "PlanPrices");

            migrationBuilder.DropTable(
                name: "PotentialConnections");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "UserBlocks");

            migrationBuilder.DropTable(
                name: "UserConnectionChanges");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UserOrganizations");

            migrationBuilder.DropTable(
                name: "WorkHistories");

            migrationBuilder.DropTable(
                name: "WorkSamples");

            migrationBuilder.DropTable(
                name: "EducationFocuses");

            migrationBuilder.DropTable(
                name: "ApplicationQuestions");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "JobRequirementGroups");

            migrationBuilder.DropTable(
                name: "InvoiceHeaders");

            migrationBuilder.DropTable(
                name: "PlanBenefits");

            migrationBuilder.DropTable(
                name: "PlanContents");

            migrationBuilder.DropTable(
                name: "UserConnections");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "SmartCodes");

            migrationBuilder.DropTable(
                name: "SmartTypes");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "SchoolClaims");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "CompanyClaims");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PartnershipSubscriptions");

            migrationBuilder.DropTable(
                name: "CompanyProfiles");

            migrationBuilder.DropTable(
                name: "PartnerPlans");
        }
    }
}
