using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using JobPortal.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            user.UserId = _context.SaveChanges();

            return user;
        }

        public void DeleteApplication(int jobOfertId, int userId)
        {
            var application = _context.UserJobOfertApplications.Where(ua => ua.UserId == userId && ua.JobOfertId == jobOfertId).FirstOrDefault();
            if (application == null) return;
            _context.UserJobOfertApplications.Remove(application);
            _context.SaveChanges();
        }

        public void DeleteFavourite(int jobOfertId, int userId)
        {
            var favourite = _context.UserJobOfertsFavourites.Where(ua => ua.UserId == userId && ua.JobOfertId == jobOfertId).FirstOrDefault();
            if (favourite == null) return;
            _context.UserJobOfertsFavourites.Remove(favourite);
            _context.SaveChanges();
        }

        public bool EmailFree(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public List<JobOfert> GetApplicationsForUser(int userId)
        {
            List<JobOfert> jobOferts = _context.UserJobOfertApplications.Where(ja => ja.UserId == userId).Select(j => j.JobOfert).ToList();
            return jobOferts;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public List<JobOfert> GetFavouritesForUser(int userId)
        {
            List<JobOfert> jobOferts = _context.UserJobOfertsFavourites.Where(jf => jf.UserId == userId).Select(j => j.JobOfert).ToList();
            return jobOferts;
        }

        public void InsertJobOfertApplication(int jobOfertId, int userId)
        {
            User? user = _context.Users.Find(userId);
            JobOfert? jobOfert = _context.JobOferts.Find(jobOfertId);
            user?.UserJobOfertsApplications.Add(new UserJobOfertApplication { JobOfert = jobOfert });
            _context.SaveChanges();
        }

        public void InsertJobOfertFavourite(int jobOfertId, int userId)
        {
            User? user = _context.Users.Find(userId);
            JobOfert? jobOfert = _context.JobOferts.Find(jobOfertId);
            user?.UserJobOfertsFavourites.Add(new UserJobOfertFavourite { JobOfert = jobOfert });
            _context.SaveChanges();
        }

        public bool NumberFree(string number)
        {
            return _context.Users.Any(u => u.PhoneNumber == number);
        }

        public int Update(int userId, UserDto dto)
        {
            User user = _context.Users.Find(userId);
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.BirthDate = dto.BirthDate;
            user.Domicile = dto.Domicile;
            _context.Update(user);
            int data = _context.SaveChanges();
            return data;
        }
    }
}
