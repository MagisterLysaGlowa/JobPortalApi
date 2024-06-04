using api.Models;
using JobPortal.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Education> Educations { get; set; } = default!;
        public DbSet<Experience> Experiences { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Ability> Abilities { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;
        public DbSet<Link> Links { get; set; } = default!;

        public DbSet<UserEducation> UserEducations { get; set; } = default!;
        public DbSet<UserExperience> UserExperiences { get; set; } = default!;
        public DbSet<UserCourse> UserCourses { get; set; } = default!;
        public DbSet<UserAbility> UserAbilities { get; set; } = default!;
        public DbSet<UserLanguage> UserLanguages { get; set; } = default!;
        public DbSet<UserLink> UserLinks { get; set; } = default!;

        public DbSet<JobOfert> JobOferts { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Benefit> Benefit { get; set; } = default!;
        public DbSet<Duty> Duty { get; set; } = default!;
        public DbSet<Requirement> Requirement { get; set; } = default!;
        public DbSet<Company> Company { get; set; } = default!;

        public DbSet<JobOfertCategory> JobOfertCategory { get; set; } = default!;
        public DbSet<JobOfertBenefit> JobOfertBenefit { get; set; } = default!;
        public DbSet<JobOfertDuty> JobOfertDuty { get; set; } = default!;
        public DbSet<JobOfertRequirement> JobOfertRequirement { get; set; } = default!;
        public DbSet<JobOfertCompany> JobOfertCompany { get; set; } = default!;

        public DbSet<UserJobOfert> UserJobOferts { get; set; } = default!;
        public DbSet<UserJobOfertApplication> UserJobOfertApplications { get; set; } = default!;
        public DbSet<UserJobOfertFavourite> UserJobOfertsFavourites { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email); });

            /*EDUCATION TO USER (MANY TO MANY)*/
            modelBuilder.Entity<UserEducation>()
                        .HasKey(ue => new { ue.UsersId, ue.EducationsId });

            modelBuilder.Entity<UserEducation>()
                        .HasOne(ue => ue.User)
                        .WithMany(u => u.UserEducations)
                        .HasForeignKey(ue => ue.UsersId);

            modelBuilder.Entity<UserEducation>()
                        .HasOne(ue => ue.Education)
                        .WithMany(e => e.UserEducations)
                        .HasForeignKey(ue => ue.EducationsId);

            /*EXPERIENCE TO USER (MANY TO MANY)*/
            modelBuilder.Entity<UserExperience>()
            .HasKey(ue => new { ue.UsersId, ue.ExperiencesId });

            modelBuilder.Entity<UserExperience>()
                        .HasOne(ue => ue.User)
                        .WithMany(u => u.UserExperiences)
                        .HasForeignKey(ue => ue.UsersId);

            modelBuilder.Entity<UserExperience>()
                        .HasOne(ue => ue.Experience)
                        .WithMany(e => e.UserExperiences)
                        .HasForeignKey(ue => ue.ExperiencesId);

            /*COURSE TO USER (MANY TO MANY)*/
            modelBuilder.Entity<UserCourse>()
                        .HasKey(uc => new { uc.UsersId, uc.CoursesId });

            modelBuilder.Entity<UserCourse>()
                        .HasOne(uc => uc.User)
                        .WithMany(u => u.UserCourses)
                        .HasForeignKey(uc => uc.UsersId);

            modelBuilder.Entity<UserCourse>()
                        .HasOne(uc => uc.Course)
                        .WithMany(e => e.UserCourses)
                        .HasForeignKey(uc => uc.CoursesId);

            /*ABILITY TO USER (MANY TO MANY)*/
            modelBuilder.Entity<UserAbility>()
                        .HasKey(ua => new { ua.UsersId, ua.AbilitiesId });

            modelBuilder.Entity<UserAbility>()
                        .HasOne(ua => ua.User)
                        .WithMany(u => u.UserAbilities)
                        .HasForeignKey(ua => ua.UsersId);

            modelBuilder.Entity<UserAbility>()
                        .HasOne(ua => ua.Ability)
                        .WithMany(e => e.UserAbilities)
                        .HasForeignKey(ua => ua.AbilitiesId);

            /*LANGUAGE TO USER (MANY TO MANY)*/
            modelBuilder.Entity<UserLanguage>()
                        .HasKey(ul => new { ul.UsersId, ul.LanguagesId });

            modelBuilder.Entity<UserLanguage>()
                        .HasOne(ul => ul.User)
                        .WithMany(u => u.UserLanguages)
                        .HasForeignKey(ul => ul.UsersId);

            modelBuilder.Entity<UserLanguage>()
                        .HasOne(ul => ul.Language)
                        .WithMany(e => e.UserLanguages)
                        .HasForeignKey(ul => ul.LanguagesId);

            /*LINK TO USER (MANY TO MANY)*/
            modelBuilder.Entity<UserLink>()
                        .HasKey(ul => new { ul.UsersId, ul.LinksId });

            modelBuilder.Entity<UserLink>()
                        .HasOne(ul => ul.User)
                        .WithMany(u => u.UserLinks)
                        .HasForeignKey(ul => ul.UsersId);

            modelBuilder.Entity<UserLink>()
                        .HasOne(ul => ul.Link)
                        .WithMany(e => e.UserLinks)
                        .HasForeignKey(ul => ul.LinksId);

            /*SETUP MANY TO MANY JOB OFERT TO CATEGORY RELATION*/
            modelBuilder.Entity<JobOfertCategory>()
                .HasKey(ue => new { ue.JobOfertId, ue.CategoryId });

            modelBuilder.Entity<JobOfertCategory>()
                .HasOne(ue => ue.JobOfert)
                .WithMany(u => u.JobOfertCategories)
                .HasForeignKey(ue => ue.JobOfertId);

            modelBuilder.Entity<JobOfertCategory>()
                .HasOne(ue => ue.Category)
                .WithMany(e => e.JobOfertCategories)
                .HasForeignKey(ue => ue.CategoryId);

            /*SETUP MANY TO MANY JOB OFERT TO BENEFIT RELATION*/
            modelBuilder.Entity<JobOfertBenefit>()
                .HasKey(ue => new { ue.JobOfertId, ue.BenefitId });

            modelBuilder.Entity<JobOfertBenefit>()
                .HasOne(ue => ue.JobOfert)
                .WithMany(u => u.JobOfertBenefits)
                .HasForeignKey(ue => ue.JobOfertId);

            modelBuilder.Entity<JobOfertBenefit>()
                .HasOne(ue => ue.Benefit)
                .WithMany(e => e.JobOfertBenefits)
                .HasForeignKey(ue => ue.BenefitId);

            /*SETUP MANY TO MANY JOB OFERT TO DUTY RELATION*/
            modelBuilder.Entity<JobOfertDuty>()
                .HasKey(ue => new { ue.JobOfertId, ue.DutyId });

            modelBuilder.Entity<JobOfertDuty>()
                .HasOne(ue => ue.JobOfert)
                .WithMany(u => u.JobOfertDuties)
                .HasForeignKey(ue => ue.JobOfertId);

            modelBuilder.Entity<JobOfertDuty>()
                .HasOne(ue => ue.Duty)
                .WithMany(e => e.JobOfertDuties)
                .HasForeignKey(ue => ue.DutyId);

            /*SETUP MANY TO MANY JOB OFERT TO REQUIREMENTS RELATION*/
            modelBuilder.Entity<JobOfertRequirement>()
                .HasKey(ue => new { ue.JobOfertId, ue.RequirementId });

            modelBuilder.Entity<JobOfertRequirement>()
                .HasOne(ue => ue.JobOfert)
                .WithMany(u => u.JobOfertRequirements)
                .HasForeignKey(ue => ue.JobOfertId);

            modelBuilder.Entity<JobOfertRequirement>()
                .HasOne(ue => ue.Requirement)
                .WithMany(e => e.JobOfertRequirements)
                .HasForeignKey(ue => ue.RequirementId);

            /*SETUP MANY TO MANY USER TO JOB OFERT RELATION*/
            modelBuilder.Entity<UserJobOfert>()
                .HasKey(ue => new { ue.UserId, ue.JobOfertId });

            modelBuilder.Entity<UserJobOfert>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserJobOferts)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserJobOfert>()
                .HasOne(ue => ue.JobOfert)
                .WithMany(e => e.UserJobOferts)
                .HasForeignKey(ue => ue.JobOfertId);

            /*SETUP MANY TO MANY USER TO JOB OFERT APPLICATION RELATION*/
            modelBuilder.Entity<UserJobOfertApplication>()
                .HasKey(ue => new { ue.UserId, ue.JobOfertId });

            modelBuilder.Entity<UserJobOfertApplication>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserJobOfertsApplications)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserJobOfertApplication>()
                .HasOne(ue => ue.JobOfert)
                .WithMany(e => e.UserJobOfertsApplications)
                .HasForeignKey(ue => ue.JobOfertId);

            /*SETUP MANY TO MANY USER TO JOB OFERT FAVOURTIES RELATION*/
            modelBuilder.Entity<UserJobOfertFavourite>()
                .HasKey(ue => new { ue.UserId, ue.JobOfertId });

            modelBuilder.Entity<UserJobOfertFavourite>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserJobOfertsFavourites)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserJobOfertFavourite>()
                .HasOne(ue => ue.JobOfert)
                .WithMany(e => e.UserJobOfertsFavourites)
                .HasForeignKey(ue => ue.JobOfertId);

            /*SETUP MANY TO MANY JOB OFERT TO COMPANY RELATION*/
            modelBuilder.Entity<JobOfertCompany>()
                .HasKey(jc => new { jc.JobOfertId, jc.CompanyId });

            modelBuilder.Entity<JobOfertCompany>()
                .HasOne(jc => jc.JobOfert)
                .WithMany(jc => jc.JobOfertCompany)
                .HasForeignKey(ue => ue.JobOfertId);

            modelBuilder.Entity<JobOfertCompany>()
                .HasOne(jc => jc.Company)
                .WithMany(jc => jc.JobOfertCompany)
                .HasForeignKey(jc => jc.CompanyId);
        }
    }
}
