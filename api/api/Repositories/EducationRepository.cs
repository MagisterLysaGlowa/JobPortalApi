using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly AppDbContext _context;
        public EducationRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Education> GetAll()
        {
            var list = _context.Educations.ToList();
            return list;
        }

        public List<Education> GetEducationsForUser(int userId)
        {
            var educations = _context.UserEducations.Where(ue => ue.UsersId == userId).Select(e => e.Education).ToList();
            return educations;
        }

        public Education Insert(int userId,Education education)
        {
            _context.Educations.Add(education);
            var user = _context.Users.Find(userId);
            user?.UserEducations.Add(new UserEducation { Education = education });
            _context.SaveChanges();
            return education;
        }

        public int Remove(int educationId)
        {
            var education = _context.Educations.Find(educationId);
            if (education == null) return 0;
            _context.Educations.Remove(education);
            _context.SaveChanges();
            return educationId;
        }

        public Education Update(int educationId, Education education)
        {
            var education_db = _context.Educations.Find(educationId);

            if (education_db == null) return null;

            education_db.SchoolName = education.SchoolName;
            education_db.EducationLevel = education.EducationLevel;
            education_db.Field = education.Field;
            education_db.Location = education.Location;
            education_db.StartDate = education.StartDate;
            education_db.EndDate = education.EndDate;

            _context.Educations.Update(education_db);
            _context.SaveChanges();
            return education_db;
        }
    }
}
