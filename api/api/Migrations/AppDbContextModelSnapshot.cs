﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobPortal.Api.Models.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BenefitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benefit");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Duty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DutyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Duty");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmploymentContract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmploymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecruitmentEndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("SalaryMaximum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SalaryMinimum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WorkDays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkEndHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkStartHour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobOferts");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertBenefit", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("BenefitId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "BenefitId");

                    b.HasIndex("BenefitId");

                    b.ToTable("JobOfertBenefit");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertCategory", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("JobOfertCategory");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertDuty", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("DutyId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "DutyId");

                    b.HasIndex("DutyId");

                    b.ToTable("JobOfertDuty");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertRequirement", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("RequirementId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "RequirementId");

                    b.HasIndex("RequirementId");

                    b.ToTable("JobOfertRequirement");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RequirementName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Requirement");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserJobOfert", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "JobOfertId");

                    b.HasIndex("JobOfertId");

                    b.ToTable("UserJobOferts");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserJobOfertApplication", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "JobOfertId");

                    b.HasIndex("JobOfertId");

                    b.ToTable("UserJobOfertApplications");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserJobOfertFavourite", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "JobOfertId");

                    b.HasIndex("JobOfertId");

                    b.ToTable("UserJobOfertsFavourites");
                });

            modelBuilder.Entity("api.Models.Ability", b =>
                {
                    b.Property<int>("AbilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbilityId"));

                    b.Property<string>("AbilityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AbilityId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("api.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("api.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseOrganizer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("api.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationId"));

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EducationId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("api.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceId"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proffesion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ExperienceId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("api.Models.JobOfertCompany", b =>
                {
                    b.Property<int>("JobOfertId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("JobOfertId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobOfertCompany");
                });

            modelBuilder.Entity("api.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"));

                    b.Property<string>("LanguageLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("api.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<string>("LinkContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Access")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Models.UserAbility", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("AbilitiesId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "AbilitiesId");

                    b.HasIndex("AbilitiesId");

                    b.ToTable("UserAbilities");
                });

            modelBuilder.Entity("api.Models.UserCourse", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("api.Models.UserEducation", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("EducationsId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "EducationsId");

                    b.HasIndex("EducationsId");

                    b.ToTable("UserEducations");
                });

            modelBuilder.Entity("api.Models.UserExperience", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("ExperiencesId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "ExperiencesId");

                    b.HasIndex("ExperiencesId");

                    b.ToTable("UserExperiences");
                });

            modelBuilder.Entity("api.Models.UserLanguage", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("LanguagesId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "LanguagesId");

                    b.HasIndex("LanguagesId");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("api.Models.UserLink", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("LinksId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "LinksId");

                    b.HasIndex("LinksId");

                    b.ToTable("UserLinks");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertBenefit", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Benefit", "Benefit")
                        .WithMany("JobOfertBenefits")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertBenefits")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("JobOfert");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertCategory", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Category", "Category")
                        .WithMany("JobOfertCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertCategories")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("JobOfert");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertDuty", b =>
                {
                    b.HasOne("JobPortal.Api.Models.Duty", "Duty")
                        .WithMany("JobOfertDuties")
                        .HasForeignKey("DutyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertDuties")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Duty");

                    b.Navigation("JobOfert");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfertRequirement", b =>
                {
                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertRequirements")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.Requirement", "Requirement")
                        .WithMany("JobOfertRequirements")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOfert");

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserJobOfert", b =>
                {
                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("UserJobOferts")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserJobOferts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOfert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserJobOfertApplication", b =>
                {
                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("UserJobOfertsApplications")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserJobOfertsApplications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOfert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.UserJobOfertFavourite", b =>
                {
                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("UserJobOfertsFavourites")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserJobOfertsFavourites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOfert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.JobOfertCompany", b =>
                {
                    b.HasOne("api.Models.Company", "Company")
                        .WithMany("JobOfertCompany")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Api.Models.JobOfert", "JobOfert")
                        .WithMany("JobOfertCompany")
                        .HasForeignKey("JobOfertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("JobOfert");
                });

            modelBuilder.Entity("api.Models.UserAbility", b =>
                {
                    b.HasOne("api.Models.Ability", "Ability")
                        .WithMany("UserAbilities")
                        .HasForeignKey("AbilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserAbilities")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserCourse", b =>
                {
                    b.HasOne("api.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserEducation", b =>
                {
                    b.HasOne("api.Models.Education", "Education")
                        .WithMany("UserEducations")
                        .HasForeignKey("EducationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserEducations")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Education");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserExperience", b =>
                {
                    b.HasOne("api.Models.Experience", "Experience")
                        .WithMany("UserExperiences")
                        .HasForeignKey("ExperiencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserExperiences")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserLanguage", b =>
                {
                    b.HasOne("api.Models.Language", "Language")
                        .WithMany("UserLanguages")
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserLanguages")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserLink", b =>
                {
                    b.HasOne("api.Models.Link", "Link")
                        .WithMany("UserLinks")
                        .HasForeignKey("LinksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserLinks")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Benefit", b =>
                {
                    b.Navigation("JobOfertBenefits");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Category", b =>
                {
                    b.Navigation("JobOfertCategories");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Duty", b =>
                {
                    b.Navigation("JobOfertDuties");
                });

            modelBuilder.Entity("JobPortal.Api.Models.JobOfert", b =>
                {
                    b.Navigation("JobOfertBenefits");

                    b.Navigation("JobOfertCategories");

                    b.Navigation("JobOfertCompany");

                    b.Navigation("JobOfertDuties");

                    b.Navigation("JobOfertRequirements");

                    b.Navigation("UserJobOferts");

                    b.Navigation("UserJobOfertsApplications");

                    b.Navigation("UserJobOfertsFavourites");
                });

            modelBuilder.Entity("JobPortal.Api.Models.Requirement", b =>
                {
                    b.Navigation("JobOfertRequirements");
                });

            modelBuilder.Entity("api.Models.Ability", b =>
                {
                    b.Navigation("UserAbilities");
                });

            modelBuilder.Entity("api.Models.Company", b =>
                {
                    b.Navigation("JobOfertCompany");
                });

            modelBuilder.Entity("api.Models.Course", b =>
                {
                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("api.Models.Education", b =>
                {
                    b.Navigation("UserEducations");
                });

            modelBuilder.Entity("api.Models.Experience", b =>
                {
                    b.Navigation("UserExperiences");
                });

            modelBuilder.Entity("api.Models.Language", b =>
                {
                    b.Navigation("UserLanguages");
                });

            modelBuilder.Entity("api.Models.Link", b =>
                {
                    b.Navigation("UserLinks");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Navigation("UserAbilities");

                    b.Navigation("UserCourses");

                    b.Navigation("UserEducations");

                    b.Navigation("UserExperiences");

                    b.Navigation("UserJobOferts");

                    b.Navigation("UserJobOfertsApplications");

                    b.Navigation("UserJobOfertsFavourites");

                    b.Navigation("UserLanguages");

                    b.Navigation("UserLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
