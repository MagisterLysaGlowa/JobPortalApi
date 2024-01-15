using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
        bool EmailFree(string email);
        bool NumberFree(string number);
    }
}
