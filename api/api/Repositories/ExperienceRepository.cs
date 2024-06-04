using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly AppDbContext _context;
        public ExperienceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Experience> GetAll()
        {
            var list = _context.Experiences.ToList();
            return list;
        }

        public List<Experience> GetExperiencesForUser(int userId)
        {
            var experiences = _context.UserExperiences.Where(ue => ue.UsersId == userId).Select(e => e.Experience).ToList();
            return experiences;
        }

        public Experience Insert(int userId, Experience experience)
        {
            _context.Experiences.Add(experience);
            var user = _context.Users.Find(userId);
            user?.UserExperiences.Add(new UserExperience { Experience = experience });
            _context.SaveChanges();
            return experience;
        }

        public int Remove(int experienceId)
        {
            var experience = _context.Experiences.Find(experienceId);
            if (experience == null) return 0;
            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return experienceId;
        }

        public Experience Update(int experienceId, Experience experience)
        {
            var experience_db = _context.Experiences.Find(experienceId);

            if (experience_db == null) return null;

            experience_db.CompanyName = experience.CompanyName;
            experience_db.Proffesion = experience.Proffesion;
            experience_db.Location = experience.Location;
            experience_db.StartDate = experience.StartDate;
            experience_db.EndDate = experience.EndDate;

            _context.Experiences.Update(experience_db);
            _context.SaveChanges();
            return experience_db;
        }
    }
}
