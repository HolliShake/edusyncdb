using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicTermDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfGradingPeriod = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsGroup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionApplicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionApplicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgencyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BulletinCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClearanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualityAssuranceAssessmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalQualityAssuranceAssessmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualityAssuranceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaLabel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaLabel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaLabel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaLabel4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalQualityAssuranceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeInputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeInputType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumericGrade = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LetterGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartRange = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    EndRange = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GradeRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeInputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradingPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradingPeriodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradingNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfChoices = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherSchools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCampus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherSchools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioIncidentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioIncidentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScopeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioSessionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioSessionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeGroup = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequirementDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScholarshipLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScholarshipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Sponsor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectorDisciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplineDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorDisciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorDisciplines_SectorDisciplines_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SectorDisciplines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkCompetencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Competency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMicroCredential = table.Column<bool>(type: "bit", nullable: false),
                    CredentialCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkCompetencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkCompetencyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetencyType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkCompetencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkCriticalWorkFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriticalWorkFunction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkCriticalWorkFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkGroupLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkGroupLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkPerformanceExpectations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformaceExpectation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkPerformanceExpectations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPercentage = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DefaultAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    VoucherCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessListActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessListActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessListActions_AccessLists_AccessListId",
                        column: x => x.AccessListId,
                        principalTable: "AccessLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TableObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uacs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    AccountGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableObjects_AccountGroups_AccountGroupId",
                        column: x => x.AccountGroupId,
                        principalTable: "AccountGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TableObjects_TableObjects_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TableObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Campuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campuses_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualityAssuranceEducationalGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EqaGoal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalQualityAssuranceEducationalGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalQualityAssuranceEducationalGoals_EducationalQualityAssuranceTypes_EqaTypeId",
                        column: x => x.EqaTypeId,
                        principalTable: "EducationalQualityAssuranceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ParameterCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterCategories_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceTagType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionSummaryText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    PostedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FollowupDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PortfolioSessionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioSessions_PortfolioSessionTypes_PortfolioSessionTypeId",
                        column: x => x.PortfolioSessionTypeId,
                        principalTable: "PortfolioSessionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScholarshipRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScholarshipListId = table.Column<int>(type: "int", nullable: false),
                    RequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScholarshipRequirements_Requirements_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScholarshipRequirements_ScholarshipLists_ScholarshipListId",
                        column: x => x.ScholarshipListId,
                        principalTable: "ScholarshipLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorDisciplineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioProviders_SectorDisciplines_SectorDisciplineId",
                        column: x => x.SectorDisciplineId,
                        principalTable: "SectorDisciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkTrackSpecializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorDisciplineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkTrackSpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkTrackSpecializations_SectorDisciplines_SectorDisciplineId",
                        column: x => x.SectorDisciplineId,
                        principalTable: "SectorDisciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkCompetencyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SfCompetencyTypeId = table.Column<int>(type: "int", nullable: false),
                    SectorDisciplineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkCompetencyCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkCompetencyCategories_SectorDisciplines_SectorDisciplineId",
                        column: x => x.SectorDisciplineId,
                        principalTable: "SectorDisciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkCompetencyCategories_SkillsFrameworkCompetencyTypes_SfCompetencyTypeId",
                        column: x => x.SfCompetencyTypeId,
                        principalTable: "SkillsFrameworkCompetencyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkKeyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SfCriticalWorkFunctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkKeyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkKeyTasks_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                        column: x => x.SfCriticalWorkFunctionId,
                        principalTable: "SkillsFrameworkCriticalWorkFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkProficiencyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SfGroupLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkProficiencyLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkProficiencyLevels_SkillsFrameworkGroupLevels_SfGroupLevelId",
                        column: x => x.SfGroupLevelId,
                        principalTable: "SkillsFrameworkGroupLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bulletins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Infographics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    BulletinCategoryId = table.Column<int>(type: "int", nullable: false),
                    PostedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bulletins_BulletinCategories_BulletinCategoryId",
                        column: x => x.BulletinCategoryId,
                        principalTable: "BulletinCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bulletins_Users_PostedByUserId",
                        column: x => x.PostedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClearanceTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettlementInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsExtensible = table.Column<bool>(type: "bit", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    IsSettled = table.Column<bool>(type: "bit", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtendedDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SettledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemindMeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClearanceTypeId = table.Column<int>(type: "int", nullable: false),
                    DuWhoTagId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UnclearedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserWhoClearedId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClearanceTags_ClearanceTypes_ClearanceTypeId",
                        column: x => x.ClearanceTypeId,
                        principalTable: "ClearanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClearanceTags_Users_DuWhoTagId",
                        column: x => x.DuWhoTagId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClearanceTags_Users_UnclearedUserId",
                        column: x => x.UnclearedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClearanceTags_Users_UserWhoClearedId",
                        column: x => x.UserWhoClearedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PortfolioIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolutionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ComplaineeUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ComplainantUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EncodedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PortfolioIncidentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioIncidents_PortfolioIncidentTypes_PortfolioIncidentTypeId",
                        column: x => x.PortfolioIncidentTypeId,
                        principalTable: "PortfolioIncidentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortfolioIncidents_Users_ComplainantUserId",
                        column: x => x.ComplainantUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PortfolioIncidents_Users_ComplaineeUserId",
                        column: x => x.ComplaineeUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PortfolioIncidents_Users_EncodedByUserId",
                        column: x => x.EncodedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccessListId = table.Column<int>(type: "int", nullable: false),
                    AccessListActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccesses_AccessListActions_AccessListActionId",
                        column: x => x.AccessListActionId,
                        principalTable: "AccessListActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserAccesses_AccessLists_AccessListId",
                        column: x => x.AccessListId,
                        principalTable: "AccessLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserAccesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FeeCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    FundSourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentFees_FundSources_FundSourceId",
                        column: x => x.FundSourceId,
                        principalTable: "FundSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrollmentFees_TableObjects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "TableObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colleges_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CycleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CylceNumber = table.Column<int>(type: "int", nullable: false),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cycles_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GraduationCampuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraduationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GraduationTheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenueLatitude = table.Column<float>(type: "real", nullable: false),
                    VenueLongitude = table.Column<float>(type: "real", nullable: false),
                    BORResolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuestOfHonor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationCampuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduationCampuses_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualityAssuranceProgramObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EqaProgramObjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaEducationalGoalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalQualityAssuranceProgramObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalQualityAssuranceProgramObjectives_EducationalQualityAssuranceEducationalGoals_EqaEducationalGoalId",
                        column: x => x.EqaEducationalGoalId,
                        principalTable: "EducationalQualityAssuranceEducationalGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ParameterSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterSubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParameterCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterSubCategories_ParameterCategories_ParameterCategoryId",
                        column: x => x.ParameterCategoryId,
                        principalTable: "ParameterCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioSessionInvolved",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDescripton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioSessionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioSessionInvolved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioSessionInvolved_PortfolioSessions_PortfolioSessionId",
                        column: x => x.PortfolioSessionId,
                        principalTable: "PortfolioSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortfolioSessionInvolved_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithLaboratory = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecialize = table.Column<bool>(type: "bit", nullable: false),
                    LectureUnits = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LaboratoryUnits = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreditUnits = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    EducationalQualityAssuranceTypeId = table.Column<int>(type: "int", nullable: false),
                    SfTrackSpecializationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_EducationalQualityAssuranceTypes_EducationalQualityAssuranceTypeId",
                        column: x => x.EducationalQualityAssuranceTypeId,
                        principalTable: "EducationalQualityAssuranceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Courses_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                        column: x => x.SfTrackSpecializationId,
                        principalTable: "SkillsFrameworkTrackSpecializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkJobRoleJobRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SfTrackSpecializationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkJobRoleJobRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkJobRoleJobRoles_SkillsFrameworkTrackSpecializations_SfTrackSpecializationId",
                        column: x => x.SfTrackSpecializationId,
                        principalTable: "SkillsFrameworkTrackSpecializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SfCompetencyCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkSkills_SkillsFrameworkCompetencyCategories_SfCompetencyCategoryId",
                        column: x => x.SfCompetencyCategoryId,
                        principalTable: "SkillsFrameworkCompetencyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioDisciplinaryActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    ActionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PostedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PortfolioIncidentId = table.Column<int>(type: "int", nullable: false),
                    ImposedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioDisciplinaryActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioDisciplinaryActions_PortfolioIncidents_PortfolioIncidentId",
                        column: x => x.PortfolioIncidentId,
                        principalTable: "PortfolioIncidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortfolioDisciplinaryActions_Users_ImposedByUserId",
                        column: x => x.ImposedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsLab = table.Column<bool>(type: "bit", nullable: false),
                    IsEspecializedLab = table.Column<bool>(type: "bit", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearFirstImplemented = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AcademicCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOpenOverride = table.Column<bool>(type: "bit", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    GradingPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicCalendars_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AcademicCalendars_GradingPeriods_GradingPeriodId",
                        column: x => x.GradingPeriodId,
                        principalTable: "GradingPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScholarshipCycleLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxNumberOfScholars = table.Column<int>(type: "int", nullable: false),
                    IsOpenOverride = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    ScholarshipListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipCycleLimits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScholarshipCycleLimits_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScholarshipCycleLimits_ScholarshipLists_ScholarshipListId",
                        column: x => x.ScholarshipListId,
                        principalTable: "ScholarshipLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualityAssuranceCourseObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EqaCourseObjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaProgramObjectiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalQualityAssuranceCourseObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalQualityAssuranceCourseObjectives_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                        column: x => x.EqaProgramObjectiveId,
                        principalTable: "EducationalQualityAssuranceProgramObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionTypeLikertOrText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ParameterSubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameters_ParameterSubCategories_ParameterSubCategoryId",
                        column: x => x.ParameterSubCategoryId,
                        principalTable: "ParameterSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Parameters_Parameters_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parameters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseCreditings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditedFromCourseTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditedFromCourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditGrades = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreditUnits = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditToUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EvaluatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreditedFromSchoolId = table.Column<int>(type: "int", nullable: false),
                    OtherSchoolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCreditings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCreditings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseCreditings_OtherSchools_OtherSchoolId",
                        column: x => x.OtherSchoolId,
                        principalTable: "OtherSchools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseCreditings_Users_CreditToUserId",
                        column: x => x.CreditToUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseCreditings_Users_EvaluatedByUserId",
                        column: x => x.EvaluatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFees_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseFees_EnrollmentFees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "EnrollmentFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CourseRequisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    RequisiteCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRequisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRequisites_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseRequisites_Courses_RequisiteCourseId",
                        column: x => x.RequisiteCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualityAssuranceProgramObjectiveToJobRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EqaProgramObjectiveId = table.Column<int>(type: "int", nullable: false),
                    SfJobRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalQualityAssuranceProgramObjectiveToJobRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_EducationalQualityAssuranceProgramObjectives_EqaProgramObjectiveId",
                        column: x => x.EqaProgramObjectiveId,
                        principalTable: "EducationalQualityAssuranceProgramObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EducationalQualityAssuranceProgramObjectiveToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                        column: x => x.SfJobRoleId,
                        principalTable: "SkillsFrameworkJobRoleJobRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SfJoBRole = table.Column<int>(type: "int", nullable: false),
                    SfJobRoleId = table.Column<int>(type: "int", nullable: true),
                    SfCriticalWorkFunctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkJobRoleToCriticalWorkFunctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkCriticalWorkFunctions_SfCriticalWorkFunctionId",
                        column: x => x.SfCriticalWorkFunctionId,
                        principalTable: "SkillsFrameworkCriticalWorkFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkJobRoleToCriticalWorkFunctions_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                        column: x => x.SfJobRoleId,
                        principalTable: "SkillsFrameworkJobRoleJobRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkPerformaceExpectationToJobRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SfJobRoleId = table.Column<int>(type: "int", nullable: false),
                    SfPerformanceExpectationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkPerformaceExpectationToJobRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkJobRoleJobRoles_SfJobRoleId",
                        column: x => x.SfJobRoleId,
                        principalTable: "SkillsFrameworkJobRoleJobRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkPerformaceExpectationToJobRoles_SkillsFrameworkPerformanceExpectations_SfPerformanceExpectationId",
                        column: x => x.SfPerformanceExpectationId,
                        principalTable: "SkillsFrameworkPerformanceExpectations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MentorOrAdviser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditPoints = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PortfolioProviderId = table.Column<int>(type: "int", nullable: false),
                    PortfolioScopeId = table.Column<int>(type: "int", nullable: false),
                    PortfolioTypeId = table.Column<int>(type: "int", nullable: false),
                    SfSkillsId = table.Column<int>(type: "int", nullable: false),
                    SfProficiencyLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioEntries_PortfolioProviders_PortfolioProviderId",
                        column: x => x.PortfolioProviderId,
                        principalTable: "PortfolioProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortfolioEntries_PortfolioScopes_PortfolioScopeId",
                        column: x => x.PortfolioScopeId,
                        principalTable: "PortfolioScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortfolioEntries_PortfolioTypes_PortfolioTypeId",
                        column: x => x.PortfolioTypeId,
                        principalTable: "PortfolioTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortfolioEntries_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                        column: x => x.SfProficiencyLevelId,
                        principalTable: "SkillsFrameworkProficiencyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortfolioEntries_SkillsFrameworkSkills_SfSkillsId",
                        column: x => x.SfSkillsId,
                        principalTable: "SkillsFrameworkSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortfolioEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkSkillsToCompetencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SfCompetencyId = table.Column<int>(type: "int", nullable: false),
                    SfSkillsId = table.Column<int>(type: "int", nullable: false),
                    SfProficiencyLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkSkillsToCompetencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkCompetencies_SfCompetencyId",
                        column: x => x.SfCompetencyId,
                        principalTable: "SkillsFrameworkCompetencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                        column: x => x.SfProficiencyLevelId,
                        principalTable: "SkillsFrameworkProficiencyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkills_SfSkillsId",
                        column: x => x.SfSkillsId,
                        principalTable: "SkillsFrameworkSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClosedOverride = table.Column<bool>(type: "bit", nullable: false),
                    IntakeLimit = table.Column<bool>(type: "bit", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionSchedules_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissionSchedules_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BulletinScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BulletinId = table.Column<int>(type: "int", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BulletinScopes_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BulletinScopes_Bulletins_BulletinId",
                        column: x => x.BulletinId,
                        principalTable: "Bulletins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Curricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurriculumCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorityLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAcademicTerm = table.Column<int>(type: "int", nullable: false),
                    MinUnitsToBeHonored = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentMaxUnits = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    AcademicTermId = table.Column<int>(type: "int", nullable: false),
                    ProgramTypeId = table.Column<int>(type: "int", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false),
                    MinGradeToBeCulledId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curricula_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Curricula_AcademicTerms_AcademicTermId",
                        column: x => x.AcademicTermId,
                        principalTable: "AcademicTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Curricula_GradeInputs_MinGradeToBeCulledId",
                        column: x => x.MinGradeToBeCulledId,
                        principalTable: "GradeInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Curricula_ProgramTypes_ProgramTypeId",
                        column: x => x.ProgramTypeId,
                        principalTable: "ProgramTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOpenOverride = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentRoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationPeriods_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EvaluationPeriods_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EvaluationPeriods_EnrollmentRoles_EnrollmentRoleId",
                        column: x => x.EnrollmentRoleId,
                        principalTable: "EnrollmentRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EvaluationPeriods_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EvaluationPeriods_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GraduationApplicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsGraduated = table.Column<bool>(type: "bit", nullable: false),
                    IsAbsentDuringGraduation = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false),
                    GraduatingStudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GraduationCampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationApplicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduationApplicants_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GraduationApplicants_GraduationCampuses_GraduationCampusId",
                        column: x => x.GraduationCampusId,
                        principalTable: "GraduationCampuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GraduationApplicants_Users_GraduatingStudentId",
                        column: x => x.GraduatingStudentId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PetitionCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetitionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetitionByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetitionCourses_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PetitionCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PetitionCourses_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PetitionCourses_Users_PetitionByUserId",
                        column: x => x.PetitionByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneratedReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneratedSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaySchedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeScheduleIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeScheduleOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinStudent = table.Column<int>(type: "int", nullable: false),
                    MaxStudent = table.Column<int>(type: "int", nullable: false),
                    IsPetitionSchedule = table.Column<bool>(type: "bit", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Schedules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Schedules_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Schedules_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScholarshipApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScholarshipCycleLimitId = table.Column<int>(type: "int", nullable: false),
                    ApplicantUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScholarshipApplications_ScholarshipCycleLimits_ScholarshipCycleLimitId",
                        column: x => x.ScholarshipCycleLimitId,
                        principalTable: "ScholarshipCycleLimits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScholarshipApplications_Users_ApplicantUserId",
                        column: x => x.ApplicantUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualityAssuranceLearningObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EqaLearningObjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaCourseObjectiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalQualityAssuranceLearningObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceCourseObjectives_EqaCourseObjectiveId",
                        column: x => x.EqaCourseObjectiveId,
                        principalTable: "EducationalQualityAssuranceCourseObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LikertQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikertScale = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    ParameterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikertQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikertQuestions_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkJobRoleToProficiencyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SfJobRoleToCriticalWorkFunctionId = table.Column<int>(type: "int", nullable: false),
                    SfSkillsId = table.Column<int>(type: "int", nullable: false),
                    SkillsFrameworkSkillsId = table.Column<int>(type: "int", nullable: true),
                    SfProficiencyLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkJobRoleToProficiencyLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkJobRoleToCriticalWorkFunctions_SfJobRoleToCriticalWorkFunctionId",
                        column: x => x.SfJobRoleToCriticalWorkFunctionId,
                        principalTable: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkProficiencyLevels_SfProficiencyLevelId",
                        column: x => x.SfProficiencyLevelId,
                        principalTable: "SkillsFrameworkProficiencyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkills_SkillsFrameworkSkillsId",
                        column: x => x.SkillsFrameworkSkillsId,
                        principalTable: "SkillsFrameworkSkills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillsFrameworkCourseToCompetencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SkillsToCompetencyId = table.Column<int>(type: "int", nullable: false),
                    SkillsFrameworkSkillsToCompetencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsFrameworkCourseToCompetencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkCourseToCompetencies_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                        column: x => x.SkillsFrameworkSkillsToCompetencyId,
                        principalTable: "SkillsFrameworkSkillsToCompetencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdmissionApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverAllStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdmissionScheduleId = table.Column<int>(type: "int", nullable: false),
                    AdmissionApplicantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionApplications_AdmissionApplicants_AdmissionApplicantId",
                        column: x => x.AdmissionApplicantId,
                        principalTable: "AdmissionApplicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissionApplications_AdmissionSchedules_AdmissionScheduleId",
                        column: x => x.AdmissionScheduleId,
                        principalTable: "AdmissionSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionEvaluationSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationScheduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationScheduleStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluationScheduleEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOnlineMode = table.Column<bool>(type: "bit", nullable: false),
                    EvaluationOnlineLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationOnlinePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionEvaluationSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionEvaluationSchedules_AdmissionSchedules_AdmissionScheduleId",
                        column: x => x.AdmissionScheduleId,
                        principalTable: "AdmissionSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionProgramRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassingScore = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AdmissionScheduleId = table.Column<int>(type: "int", nullable: false),
                    RequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionProgramRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionProgramRequirements_AdmissionSchedules_AdmissionScheduleId",
                        column: x => x.AdmissionScheduleId,
                        principalTable: "AdmissionSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissionProgramRequirements_Requirements_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearLevel = table.Column<int>(type: "int", nullable: false),
                    TermNumber = table.Column<int>(type: "int", nullable: false),
                    IsIncludeGWA = table.Column<bool>(type: "bit", nullable: false),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumDetails_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CurriculumDetails_Curricula_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentDateTime = table.Column<int>(type: "int", nullable: false),
                    YearLEvel = table.Column<int>(type: "int", nullable: false),
                    CreditUnits = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    GradeOverallStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValidated = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_EnrollmentRoles_EnrollmentRoleId",
                        column: x => x.EnrollmentRoleId,
                        principalTable: "EnrollmentRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Enrollments_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GradeBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeBookDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeBooks_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InLatitude = table.Column<float>(type: "real", nullable: false),
                    InLongitude = table.Column<float>(type: "real", nullable: false),
                    OutLatitude = table.Column<float>(type: "real", nullable: false),
                    OutLongitude = table.Column<float>(type: "real", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    AnyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleAttendances_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScheduleAttendances_Users_AnyUserId",
                        column: x => x.AnyUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleMerges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MergeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleMerges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleMerges_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EnrollmentRoleId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleTeachers_EnrollmentRoles_EnrollmentRoleId",
                        column: x => x.EnrollmentRoleId,
                        principalTable: "EnrollmentRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScheduleTeachers_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScheduleTeachers_Users_TeacherUserId",
                        column: x => x.TeacherUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScholarshipEvaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvalScore = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    EvaluatorUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ScholarshipApplicationId = table.Column<int>(type: "int", nullable: false),
                    ScholarshipRequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScholarshipEvaluations_ScholarshipApplications_ScholarshipApplicationId",
                        column: x => x.ScholarshipApplicationId,
                        principalTable: "ScholarshipApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScholarshipEvaluations_ScholarshipRequirements_ScholarshipRequirementId",
                        column: x => x.ScholarshipRequirementId,
                        principalTable: "ScholarshipRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScholarshipEvaluations_Users_EvaluatorUserId",
                        column: x => x.EvaluatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseToLearningObjectiveMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LearningObjectiveId = table.Column<int>(type: "int", nullable: false),
                    EducationalQualityAssuranceLearningObjectiveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseToLearningObjectiveMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseToLearningObjectiveMappings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EducationalQualityAssuranceLearningObjective~",
                        column: x => x.EducationalQualityAssuranceLearningObjectiveId,
                        principalTable: "EducationalQualityAssuranceLearningObjectives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdmissionScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualScore = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    EvaluationRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationPostDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdmissionEvaluationScheduleId = table.Column<int>(type: "int", nullable: false),
                    AdmissionProgramRequirementId = table.Column<int>(type: "int", nullable: false),
                    AdmissionApplicantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionScores_AdmissionApplicants_AdmissionApplicantId",
                        column: x => x.AdmissionApplicantId,
                        principalTable: "AdmissionApplicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissionScores_AdmissionEvaluationSchedules_AdmissionEvaluationScheduleId",
                        column: x => x.AdmissionEvaluationScheduleId,
                        principalTable: "AdmissionEvaluationSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissionScores_AdmissionProgramRequirements_AdmissionProgramRequirementId",
                        column: x => x.AdmissionProgramRequirementId,
                        principalTable: "AdmissionProgramRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdmissionScores_Users_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentBillings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingParticulars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    BillingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentFeeId = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentBillings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentBillings_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrollmentBillings_EnrollmentFees_EnrollmentFeeId",
                        column: x => x.EnrollmentFeeId,
                        principalTable: "EnrollmentFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrollmentBillings_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrollmentBillings_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    GradeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    GradingInput = table.Column<int>(type: "int", nullable: false),
                    GradeInputId = table.Column<int>(type: "int", nullable: true),
                    GradingPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentGrades_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrollmentGrades_GradeInputs_GradeInputId",
                        column: x => x.GradeInputId,
                        principalTable: "GradeInputs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EnrollmentGrades_GradingPeriods_GradingPeriodId",
                        column: x => x.GradingPeriodId,
                        principalTable: "GradingPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetworkAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    LogByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentLogs_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrollmentLogs_Users_LogByUserId",
                        column: x => x.LogByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OverallComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    RatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    EvaluationPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationRatings_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EvaluationRatings_EvaluationPeriods_EvaluationPeriodId",
                        column: x => x.EvaluationPeriodId,
                        principalTable: "EvaluationPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GradeBookScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GradeBookItemDetailId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeBookScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeBookScores_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GradeBookItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GradeBookId = table.Column<int>(type: "int", nullable: false),
                    GradingPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeBookItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeBookItems_GradeBooks_GradeBookId",
                        column: x => x.GradeBookId,
                        principalTable: "GradeBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GradeBookItems_GradingPeriods_GradingPeriodId",
                        column: x => x.GradingPeriodId,
                        principalTable: "GradingPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ORNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    EnrollmentBillingId = table.Column<int>(type: "int", nullable: false),
                    CashierId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentPayments_EnrollmentBillings_EnrollmentBillingId",
                        column: x => x.EnrollmentBillingId,
                        principalTable: "EnrollmentBillings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrollmentPayments_Users_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VoucherApplied",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentBillingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherApplied", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherApplied_EnrollmentBillings_EnrollmentBillingId",
                        column: x => x.EnrollmentBillingId,
                        principalTable: "EnrollmentBillings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VoucherApplied_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationRatingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikertScaleResponse = table.Column<int>(type: "int", nullable: false),
                    QuestionTextResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaulationRatingId = table.Column<int>(type: "int", nullable: false),
                    EvaluationRatingId = table.Column<int>(type: "int", nullable: true),
                    LikertQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationRatingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationRatingDetails_EvaluationRatings_EvaluationRatingId",
                        column: x => x.EvaluationRatingId,
                        principalTable: "EvaluationRatings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvaluationRatingDetails_LikertQuestions_LikertQuestionId",
                        column: x => x.LikertQuestionId,
                        principalTable: "LikertQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GradeBookItemDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxScore = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PassingScore = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GradeBookItemId = table.Column<int>(type: "int", nullable: false),
                    EqaAssessmentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeBookItemDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeBookItemDetails_EducationalQualityAssuranceAssessmentTypes_EqaAssessmentTypeId",
                        column: x => x.EqaAssessmentTypeId,
                        principalTable: "EducationalQualityAssuranceAssessmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GradeBookItemDetails_GradeBookItems_GradeBookItemId",
                        column: x => x.GradeBookItemId,
                        principalTable: "GradeBookItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GradeBookItemToEqaLearningObjectiveMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeBookItemDetailId = table.Column<int>(type: "int", nullable: false),
                    EqaLearningObjectiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeBookItemToEqaLearningObjectiveMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeBookItemToEqaLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectives_EqaLearningObjectiveId",
                        column: x => x.EqaLearningObjectiveId,
                        principalTable: "EducationalQualityAssuranceLearningObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GradeBookItemToEqaLearningObjectiveMappings_GradeBookItemDetails_GradeBookItemDetailId",
                        column: x => x.GradeBookItemDetailId,
                        principalTable: "GradeBookItemDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AccessLists",
                columns: new[] { "Id", "IsGroup", "Subject" },
                values: new object[,]
                {
                    { 1, true, "Auth" },
                    { 2, true, "Admin" },
                    { 3, true, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AccessListActions",
                columns: new[] { "Id", "AccessListId", "Action" },
                values: new object[,]
                {
                    { 1, 1, "all" },
                    { 2, 1, "read" },
                    { 3, 1, "create" },
                    { 4, 1, "update" },
                    { 5, 1, "delete" },
                    { 6, 2, "all" },
                    { 7, 2, "read" },
                    { 8, 2, "create" },
                    { 9, 2, "update" },
                    { 10, 2, "delete" },
                    { 11, 3, "all" },
                    { 12, 3, "read" },
                    { 13, 3, "create" },
                    { 14, 3, "update" },
                    { 15, 3, "delete" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCalendars_CycleId",
                table: "AcademicCalendars",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCalendars_GradingPeriodId",
                table: "AcademicCalendars",
                column: "GradingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_CollegeId",
                table: "AcademicPrograms",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessListActions_AccessListId",
                table: "AccessListActions",
                column: "AccessListId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLists_Subject",
                table: "AccessLists",
                column: "Subject",
                unique: true,
                filter: "[Subject] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionApplications_AdmissionApplicantId",
                table: "AdmissionApplications",
                column: "AdmissionApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionApplications_AdmissionScheduleId",
                table: "AdmissionApplications",
                column: "AdmissionScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionEvaluationSchedules_AdmissionScheduleId",
                table: "AdmissionEvaluationSchedules",
                column: "AdmissionScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionProgramRequirements_AdmissionScheduleId",
                table: "AdmissionProgramRequirements",
                column: "AdmissionScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionProgramRequirements_RequirementId",
                table: "AdmissionProgramRequirements",
                column: "RequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionSchedules_AcademicProgramId",
                table: "AdmissionSchedules",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionSchedules_CycleId",
                table: "AdmissionSchedules",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionScores_AdmissionApplicantId",
                table: "AdmissionScores",
                column: "AdmissionApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionScores_AdmissionEvaluationScheduleId",
                table: "AdmissionScores",
                column: "AdmissionEvaluationScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionScores_AdmissionProgramRequirementId",
                table: "AdmissionScores",
                column: "AdmissionProgramRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionScores_EvaluatorId",
                table: "AdmissionScores",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CampusId",
                table: "Buildings",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletins_BulletinCategoryId",
                table: "Bulletins",
                column: "BulletinCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletins_PostedByUserId",
                table: "Bulletins",
                column: "PostedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BulletinScopes_AcademicProgramId",
                table: "BulletinScopes",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_BulletinScopes_BulletinId",
                table: "BulletinScopes",
                column: "BulletinId");

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_AgencyId",
                table: "Campuses",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceTags_ClearanceTypeId",
                table: "ClearanceTags",
                column: "ClearanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceTags_DuWhoTagId",
                table: "ClearanceTags",
                column: "DuWhoTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceTags_UnclearedUserId",
                table: "ClearanceTags",
                column: "UnclearedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClearanceTags_UserWhoClearedId",
                table: "ClearanceTags",
                column: "UserWhoClearedId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_CampusId",
                table: "Colleges",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCreditings_CourseId",
                table: "CourseCreditings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCreditings_CreditToUserId",
                table: "CourseCreditings",
                column: "CreditToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCreditings_EvaluatedByUserId",
                table: "CourseCreditings",
                column: "EvaluatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCreditings_OtherSchoolId",
                table: "CourseCreditings",
                column: "OtherSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFees_CourseId",
                table: "CourseFees",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFees_FeeId",
                table: "CourseFees",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRequisites_CourseId",
                table: "CourseRequisites",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRequisites_RequisiteCourseId",
                table: "CourseRequisites",
                column: "RequisiteCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EducationalQualityAssuranceTypeId",
                table: "Courses",
                column: "EducationalQualityAssuranceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SfTrackSpecializationId",
                table: "Courses",
                column: "SfTrackSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseToLearningObjectiveMappings_CourseId",
                table: "CourseToLearningObjectiveMappings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseToLearningObjectiveMappings_EducationalQualityAssuranceLearningObjectiveId",
                table: "CourseToLearningObjectiveMappings",
                column: "EducationalQualityAssuranceLearningObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_AcademicProgramId",
                table: "Curricula",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_AcademicTermId",
                table: "Curricula",
                column: "AcademicTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_MinGradeToBeCulledId",
                table: "Curricula",
                column: "MinGradeToBeCulledId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_ProgramTypeId",
                table: "Curricula",
                column: "ProgramTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumDetails_CourseId",
                table: "CurriculumDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumDetails_CurriculumId",
                table: "CurriculumDetails",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_CampusId",
                table: "Cycles",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualityAssuranceCourseObjectives_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceCourseObjectives",
                column: "EqaProgramObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualityAssuranceEducationalGoals_EqaTypeId",
                table: "EducationalQualityAssuranceEducationalGoals",
                column: "EqaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualityAssuranceLearningObjectives_EqaCourseObjectiveId",
                table: "EducationalQualityAssuranceLearningObjectives",
                column: "EqaCourseObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualityAssuranceProgramObjectives_EqaEducationalGoalId",
                table: "EducationalQualityAssuranceProgramObjectives",
                column: "EqaEducationalGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualityAssuranceProgramObjectiveToJobRoles_EqaProgramObjectiveId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles",
                column: "EqaProgramObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualityAssuranceProgramObjectiveToJobRoles_SfJobRoleId",
                table: "EducationalQualityAssuranceProgramObjectiveToJobRoles",
                column: "SfJobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentBillings_CycleId",
                table: "EnrollmentBillings",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentBillings_EnrollmentFeeId",
                table: "EnrollmentBillings",
                column: "EnrollmentFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentBillings_EnrollmentId",
                table: "EnrollmentBillings",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentBillings_VoucherId",
                table: "EnrollmentBillings",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentFees_FundSourceId",
                table: "EnrollmentFees",
                column: "FundSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentFees_ObjectId",
                table: "EnrollmentFees",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentGrades_EnrollmentId",
                table: "EnrollmentGrades",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentGrades_GradeInputId",
                table: "EnrollmentGrades",
                column: "GradeInputId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentGrades_GradingPeriodId",
                table: "EnrollmentGrades",
                column: "GradingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentLogs_EnrollmentId",
                table: "EnrollmentLogs",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentLogs_LogByUserId",
                table: "EnrollmentLogs",
                column: "LogByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentPayments_CashierId",
                table: "EnrollmentPayments",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentPayments_EnrollmentBillingId",
                table: "EnrollmentPayments",
                column: "EnrollmentBillingId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentRoleId",
                table: "Enrollments",
                column: "EnrollmentRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ScheduleId",
                table: "Enrollments",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentUserId",
                table: "Enrollments",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPeriods_AcademicProgramId",
                table: "EvaluationPeriods",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPeriods_CreatedByUserId",
                table: "EvaluationPeriods",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPeriods_CycleId",
                table: "EvaluationPeriods",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPeriods_EnrollmentRoleId",
                table: "EvaluationPeriods",
                column: "EnrollmentRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPeriods_InstrumentId",
                table: "EvaluationPeriods",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationRatingDetails_EvaluationRatingId",
                table: "EvaluationRatingDetails",
                column: "EvaluationRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationRatingDetails_LikertQuestionId",
                table: "EvaluationRatingDetails",
                column: "LikertQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationRatings_EnrollmentId",
                table: "EvaluationRatings",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationRatings_EvaluationPeriodId",
                table: "EvaluationRatings",
                column: "EvaluationPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeBookItemDetails_EqaAssessmentTypeId",
                table: "GradeBookItemDetails",
                column: "EqaAssessmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeBookItemDetails_GradeBookItemId",
                table: "GradeBookItemDetails",
                column: "GradeBookItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeBookItems_GradeBookId",
                table: "GradeBookItems",
                column: "GradeBookId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeBookItems_GradingPeriodId",
                table: "GradeBookItems",
                column: "GradingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeBookItemToEqaLearningObjectiveMappings_EqaLearningObjectiveId",
                table: "GradeBookItemToEqaLearningObjectiveMappings",
                column: "EqaLearningObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeBookItemToEqaLearningObjectiveMappings_GradeBookItemDetailId",
                table: "GradeBookItemToEqaLearningObjectiveMappings",
                column: "GradeBookItemDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeBooks_ScheduleId",
                table: "GradeBooks",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeBookScores_EnrollmentId",
                table: "GradeBookScores",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationApplicants_AcademicProgramId",
                table: "GraduationApplicants",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationApplicants_GraduatingStudentId",
                table: "GraduationApplicants",
                column: "GraduatingStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationApplicants_GraduationCampusId",
                table: "GraduationApplicants",
                column: "GraduationCampusId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationCampuses_CampusId",
                table: "GraduationCampuses",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_LikertQuestions_ParameterId",
                table: "LikertQuestions",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterCategories_InstrumentId",
                table: "ParameterCategories",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_ParameterSubCategoryId",
                table: "Parameters",
                column: "ParameterSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_ParentId",
                table: "Parameters",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterSubCategories_ParameterCategoryId",
                table: "ParameterSubCategories",
                column: "ParameterCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PetitionCourses_AcademicProgramId",
                table: "PetitionCourses",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PetitionCourses_CourseId",
                table: "PetitionCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PetitionCourses_CycleId",
                table: "PetitionCourses",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_PetitionCourses_PetitionByUserId",
                table: "PetitionCourses",
                column: "PetitionByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioDisciplinaryActions_ImposedByUserId",
                table: "PortfolioDisciplinaryActions",
                column: "ImposedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioDisciplinaryActions_PortfolioIncidentId",
                table: "PortfolioDisciplinaryActions",
                column: "PortfolioIncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioEntries_PortfolioProviderId",
                table: "PortfolioEntries",
                column: "PortfolioProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioEntries_PortfolioScopeId",
                table: "PortfolioEntries",
                column: "PortfolioScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioEntries_PortfolioTypeId",
                table: "PortfolioEntries",
                column: "PortfolioTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioEntries_SfProficiencyLevelId",
                table: "PortfolioEntries",
                column: "SfProficiencyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioEntries_SfSkillsId",
                table: "PortfolioEntries",
                column: "SfSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioEntries_UserId",
                table: "PortfolioEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioIncidents_ComplainantUserId",
                table: "PortfolioIncidents",
                column: "ComplainantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioIncidents_ComplaineeUserId",
                table: "PortfolioIncidents",
                column: "ComplaineeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioIncidents_EncodedByUserId",
                table: "PortfolioIncidents",
                column: "EncodedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioIncidents_PortfolioIncidentTypeId",
                table: "PortfolioIncidents",
                column: "PortfolioIncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioProviders_SectorDisciplineId",
                table: "PortfolioProviders",
                column: "SectorDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSessionInvolved_PortfolioSessionId",
                table: "PortfolioSessionInvolved",
                column: "PortfolioSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSessionInvolved_UserId",
                table: "PortfolioSessionInvolved",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioSessions_PortfolioSessionTypeId",
                table: "PortfolioSessions",
                column: "PortfolioSessionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAttendances_AnyUserId",
                table: "ScheduleAttendances",
                column: "AnyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAttendances_ScheduleId",
                table: "ScheduleAttendances",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleMerges_ScheduleId",
                table: "ScheduleMerges",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AcademicProgramId",
                table: "Schedules",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CourseId",
                table: "Schedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CycleId",
                table: "Schedules",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RoomId",
                table: "Schedules",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTeachers_EnrollmentRoleId",
                table: "ScheduleTeachers",
                column: "EnrollmentRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTeachers_ScheduleId",
                table: "ScheduleTeachers",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTeachers_TeacherUserId",
                table: "ScheduleTeachers",
                column: "TeacherUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipApplications_ApplicantUserId",
                table: "ScholarshipApplications",
                column: "ApplicantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipApplications_ScholarshipCycleLimitId",
                table: "ScholarshipApplications",
                column: "ScholarshipCycleLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipCycleLimits_CycleId",
                table: "ScholarshipCycleLimits",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipCycleLimits_ScholarshipListId",
                table: "ScholarshipCycleLimits",
                column: "ScholarshipListId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipEvaluations_EvaluatorUserId",
                table: "ScholarshipEvaluations",
                column: "EvaluatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipEvaluations_ScholarshipApplicationId",
                table: "ScholarshipEvaluations",
                column: "ScholarshipApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipEvaluations_ScholarshipRequirementId",
                table: "ScholarshipEvaluations",
                column: "ScholarshipRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipRequirements_RequirementId",
                table: "ScholarshipRequirements",
                column: "RequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipRequirements_ScholarshipListId",
                table: "ScholarshipRequirements",
                column: "ScholarshipListId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorDisciplines_ParentId",
                table: "SectorDisciplines",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkCompetencyCategories_SectorDisciplineId",
                table: "SkillsFrameworkCompetencyCategories",
                column: "SectorDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkCompetencyCategories_SfCompetencyTypeId",
                table: "SkillsFrameworkCompetencyCategories",
                column: "SfCompetencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkCourseToCompetencies_CourseId",
                table: "SkillsFrameworkCourseToCompetencies",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkCourseToCompetencies_SkillsFrameworkSkillsToCompetencyId",
                table: "SkillsFrameworkCourseToCompetencies",
                column: "SkillsFrameworkSkillsToCompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkJobRoleJobRoles_SfTrackSpecializationId",
                table: "SkillsFrameworkJobRoleJobRoles",
                column: "SfTrackSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkJobRoleToCriticalWorkFunctions_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                column: "SfCriticalWorkFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkJobRoleToCriticalWorkFunctions_SfJobRoleId",
                table: "SkillsFrameworkJobRoleToCriticalWorkFunctions",
                column: "SfJobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkJobRoleToProficiencyLevels_SfJobRoleToCriticalWorkFunctionId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SfJobRoleToCriticalWorkFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkJobRoleToProficiencyLevels_SfProficiencyLevelId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SfProficiencyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkJobRoleToProficiencyLevels_SkillsFrameworkSkillsId",
                table: "SkillsFrameworkJobRoleToProficiencyLevels",
                column: "SkillsFrameworkSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkKeyTasks_SfCriticalWorkFunctionId",
                table: "SkillsFrameworkKeyTasks",
                column: "SfCriticalWorkFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkPerformaceExpectationToJobRoles_SfJobRoleId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles",
                column: "SfJobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkPerformaceExpectationToJobRoles_SfPerformanceExpectationId",
                table: "SkillsFrameworkPerformaceExpectationToJobRoles",
                column: "SfPerformanceExpectationId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkProficiencyLevels_SfGroupLevelId",
                table: "SkillsFrameworkProficiencyLevels",
                column: "SfGroupLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkSkills_SfCompetencyCategoryId",
                table: "SkillsFrameworkSkills",
                column: "SfCompetencyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkSkillsToCompetencies_SfCompetencyId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfCompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkSkillsToCompetencies_SfProficiencyLevelId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfProficiencyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkSkillsToCompetencies_SfSkillsId",
                table: "SkillsFrameworkSkillsToCompetencies",
                column: "SfSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsFrameworkTrackSpecializations_SectorDisciplineId",
                table: "SkillsFrameworkTrackSpecializations",
                column: "SectorDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_TableObjects_AccountGroupId",
                table: "TableObjects",
                column: "AccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TableObjects_ParentId",
                table: "TableObjects",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_AccessListActionId",
                table: "UserAccesses",
                column: "AccessListActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_AccessListId",
                table: "UserAccesses",
                column: "AccessListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_UserId",
                table: "UserAccesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherApplied_EnrollmentBillingId",
                table: "VoucherApplied",
                column: "EnrollmentBillingId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherApplied_VoucherId",
                table: "VoucherApplied",
                column: "VoucherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicCalendars");

            migrationBuilder.DropTable(
                name: "AdmissionApplications");

            migrationBuilder.DropTable(
                name: "AdmissionScores");

            migrationBuilder.DropTable(
                name: "BulletinScopes");

            migrationBuilder.DropTable(
                name: "ClearanceTags");

            migrationBuilder.DropTable(
                name: "CourseCreditings");

            migrationBuilder.DropTable(
                name: "CourseFees");

            migrationBuilder.DropTable(
                name: "CourseRequisites");

            migrationBuilder.DropTable(
                name: "CourseToLearningObjectiveMappings");

            migrationBuilder.DropTable(
                name: "CurriculumDetails");

            migrationBuilder.DropTable(
                name: "EducationalQualityAssuranceProgramObjectiveToJobRoles");

            migrationBuilder.DropTable(
                name: "EnrollmentGrades");

            migrationBuilder.DropTable(
                name: "EnrollmentLogs");

            migrationBuilder.DropTable(
                name: "EnrollmentPayments");

            migrationBuilder.DropTable(
                name: "EvaluationRatingDetails");

            migrationBuilder.DropTable(
                name: "FileTables");

            migrationBuilder.DropTable(
                name: "GradeBookItemToEqaLearningObjectiveMappings");

            migrationBuilder.DropTable(
                name: "GradeBookScores");

            migrationBuilder.DropTable(
                name: "GraduationApplicants");

            migrationBuilder.DropTable(
                name: "PetitionCourses");

            migrationBuilder.DropTable(
                name: "PortfolioDisciplinaryActions");

            migrationBuilder.DropTable(
                name: "PortfolioEntries");

            migrationBuilder.DropTable(
                name: "PortfolioSessionInvolved");

            migrationBuilder.DropTable(
                name: "ScheduleAttendances");

            migrationBuilder.DropTable(
                name: "ScheduleMerges");

            migrationBuilder.DropTable(
                name: "ScheduleTeachers");

            migrationBuilder.DropTable(
                name: "ScholarshipEvaluations");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkCourseToCompetencies");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkJobRoleToProficiencyLevels");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkKeyTasks");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkPerformaceExpectationToJobRoles");

            migrationBuilder.DropTable(
                name: "UserAccesses");

            migrationBuilder.DropTable(
                name: "VoucherApplied");

            migrationBuilder.DropTable(
                name: "AdmissionApplicants");

            migrationBuilder.DropTable(
                name: "AdmissionEvaluationSchedules");

            migrationBuilder.DropTable(
                name: "AdmissionProgramRequirements");

            migrationBuilder.DropTable(
                name: "Bulletins");

            migrationBuilder.DropTable(
                name: "ClearanceTypes");

            migrationBuilder.DropTable(
                name: "OtherSchools");

            migrationBuilder.DropTable(
                name: "Curricula");

            migrationBuilder.DropTable(
                name: "EvaluationRatings");

            migrationBuilder.DropTable(
                name: "LikertQuestions");

            migrationBuilder.DropTable(
                name: "EducationalQualityAssuranceLearningObjectives");

            migrationBuilder.DropTable(
                name: "GradeBookItemDetails");

            migrationBuilder.DropTable(
                name: "GraduationCampuses");

            migrationBuilder.DropTable(
                name: "PortfolioIncidents");

            migrationBuilder.DropTable(
                name: "PortfolioProviders");

            migrationBuilder.DropTable(
                name: "PortfolioScopes");

            migrationBuilder.DropTable(
                name: "PortfolioTypes");

            migrationBuilder.DropTable(
                name: "PortfolioSessions");

            migrationBuilder.DropTable(
                name: "ScholarshipApplications");

            migrationBuilder.DropTable(
                name: "ScholarshipRequirements");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkSkillsToCompetencies");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkJobRoleToCriticalWorkFunctions");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkPerformanceExpectations");

            migrationBuilder.DropTable(
                name: "AccessListActions");

            migrationBuilder.DropTable(
                name: "EnrollmentBillings");

            migrationBuilder.DropTable(
                name: "AdmissionSchedules");

            migrationBuilder.DropTable(
                name: "BulletinCategories");

            migrationBuilder.DropTable(
                name: "AcademicTerms");

            migrationBuilder.DropTable(
                name: "GradeInputs");

            migrationBuilder.DropTable(
                name: "ProgramTypes");

            migrationBuilder.DropTable(
                name: "EvaluationPeriods");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "EducationalQualityAssuranceCourseObjectives");

            migrationBuilder.DropTable(
                name: "EducationalQualityAssuranceAssessmentTypes");

            migrationBuilder.DropTable(
                name: "GradeBookItems");

            migrationBuilder.DropTable(
                name: "PortfolioIncidentTypes");

            migrationBuilder.DropTable(
                name: "PortfolioSessionTypes");

            migrationBuilder.DropTable(
                name: "ScholarshipCycleLimits");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkCompetencies");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkProficiencyLevels");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkSkills");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkCriticalWorkFunctions");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkJobRoleJobRoles");

            migrationBuilder.DropTable(
                name: "AccessLists");

            migrationBuilder.DropTable(
                name: "EnrollmentFees");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "ParameterSubCategories");

            migrationBuilder.DropTable(
                name: "EducationalQualityAssuranceProgramObjectives");

            migrationBuilder.DropTable(
                name: "GradeBooks");

            migrationBuilder.DropTable(
                name: "GradingPeriods");

            migrationBuilder.DropTable(
                name: "ScholarshipLists");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkGroupLevels");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkCompetencyCategories");

            migrationBuilder.DropTable(
                name: "FundSources");

            migrationBuilder.DropTable(
                name: "TableObjects");

            migrationBuilder.DropTable(
                name: "EnrollmentRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParameterCategories");

            migrationBuilder.DropTable(
                name: "EducationalQualityAssuranceEducationalGoals");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkCompetencyTypes");

            migrationBuilder.DropTable(
                name: "AccountGroups");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "EducationalQualityAssuranceTypes");

            migrationBuilder.DropTable(
                name: "SkillsFrameworkTrackSpecializations");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "SectorDisciplines");

            migrationBuilder.DropTable(
                name: "Campuses");

            migrationBuilder.DropTable(
                name: "Agencies");
        }
    }
}
