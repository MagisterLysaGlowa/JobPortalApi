using api.Data;
using api.Interfaces;
using api.Models;

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

        public bool EmailFree(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public bool NumberFree(string number)
        {
            return _context.Users.Any(u => u.PhoneNumber == number);
        }
    }
}
