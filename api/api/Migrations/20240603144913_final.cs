using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityId);
                });

            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOrganizer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Duty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DutyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proffesion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceId);
                });

            migrationBuilder.CreateTable(
                name: "JobOferts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruitmentEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentContract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryMinimum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalaryMaximum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WorkDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkStartHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkEndHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOferts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domicile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertBenefit",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    BenefitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertBenefit", x => new { x.JobOfertId, x.BenefitId });
                    table.ForeignKey(
                        name: "FK_JobOfertBenefit_Benefit_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertBenefit_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertCategory",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertCategory", x => new { x.JobOfertId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_JobOfertCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertCategory_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertCompany",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertCompany", x => new { x.JobOfertId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_JobOfertCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertCompany_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertDuty",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    DutyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertDuty", x => new { x.JobOfertId, x.DutyId });
                    table.ForeignKey(
                        name: "FK_JobOfertDuty_Duty_DutyId",
                        column: x => x.DutyId,
                        principalTable: "Duty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertDuty_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfertRequirement",
                columns: table => new
                {
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    RequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfertRequirement", x => new { x.JobOfertId, x.RequirementId });
                    table.ForeignKey(
                        name: "FK_JobOfertRequirement_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfertRequirement_Requirement_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAbilities",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    AbilitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAbilities", x => new { x.UsersId, x.AbilitiesId });
                    table.ForeignKey(
                        name: "FK_UserAbilities_Abilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "Abilities",
                        principalColumn: "AbilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAbilities_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => new { x.UsersId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourses_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEducations",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    EducationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducations", x => new { x.UsersId, x.EducationsId });
                    table.ForeignKey(
                        name: "FK_UserEducations_Educations_EducationsId",
                        column: x => x.EducationsId,
                        principalTable: "Educations",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEducations_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExperiences",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    ExperiencesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExperiences", x => new { x.UsersId, x.ExperiencesId });
                    table.ForeignKey(
                        name: "FK_UserExperiences_Experiences_ExperiencesId",
                        column: x => x.ExperiencesId,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExperiences_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJobOfertApplications",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobOfertId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobOfertApplications", x => new { x.UserId, x.JobOfertId });
                    table.ForeignKey(
                        name: "FK_UserJobOfertApplications_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJobOfertApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJobOferts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobOfertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobOferts", x => new { x.UserId, x.JobOfertId });
                    table.ForeignKey(
                        name: "FK_UserJobOferts_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJobOferts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJobOfertsFavourites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobOfertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobOfertsFavourites", x => new { x.UserId, x.JobOfertId });
                    table.ForeignKey(
                        name: "FK_UserJobOfertsFavourites_JobOferts_JobOfertId",
                        column: x => x.JobOfertId,
                        principalTable: "JobOferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJobOfertsFavourites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => new { x.UsersId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_UserLanguages_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLinks",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    LinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLinks", x => new { x.UsersId, x.LinksId });
                    table.ForeignKey(
                        name: "FK_UserLinks_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLinks_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertBenefit_BenefitId",
                table: "JobOfertBenefit",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertCategory_CategoryId",
                table: "JobOfertCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertCompany_CompanyId",
                table: "JobOfertCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertDuty_DutyId",
                table: "JobOfertDuty",
                column: "DutyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfertRequirement_RequirementId",
                table: "JobOfertRequirement",
                column: "RequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAbilities_AbilitiesId",
                table: "UserAbilities",
                column: "AbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CoursesId",
                table: "UserCourses",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducations_EducationsId",
                table: "UserEducations",
                column: "EducationsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_ExperiencesId",
                table: "UserExperiences",
                column: "ExperiencesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobOfertApplications_JobOfertId",
                table: "UserJobOfertApplications",
                column: "JobOfertId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobOferts_JobOfertId",
                table: "UserJobOferts",
                column: "JobOfertId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobOfertsFavourites_JobOfertId",
                table: "UserJobOfertsFavourites",
                column: "JobOfertId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguagesId",
                table: "UserLanguages",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLinks_LinksId",
                table: "UserLinks",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOfertBenefit");

            migrationBuilder.DropTable(
                name: "JobOfertCategory");

            migrationBuilder.DropTable(
                name: "JobOfertCompany");

            migrationBuilder.DropTable(
                name: "JobOfertDuty");

            migrationBuilder.DropTable(
                name: "JobOfertRequirement");

            migrationBuilder.DropTable(
                name: "UserAbilities");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "UserEducations");

            migrationBuilder.DropTable(
                name: "UserExperiences");

            migrationBuilder.DropTable(
                name: "UserJobOfertApplications");

            migrationBuilder.DropTable(
                name: "UserJobOferts");

            migrationBuilder.DropTable(
                name: "UserJobOfertsFavourites");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "UserLinks");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Duty");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "JobOferts");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
