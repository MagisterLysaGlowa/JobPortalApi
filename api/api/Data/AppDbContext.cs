using api.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email)
                                                        .IsUnique(); });

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
        }
    }
}
