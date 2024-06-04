using api.Dtos;
using api.Models;
using JobPortal.Api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
        bool EmailFree(string email);
        bool NumberFree(string number);
        void InsertJobOfertApplication(int jobOfertId,int userId);
        void InsertJobOfertFavourite(int jobOfertId,int userId);
        void DeleteFavourite(int jobOfertId, int userId);
        void DeleteApplication(int jobOfertId, int userId);
        List<JobOfert> GetApplicationsForUser(int userId);
        List<JobOfert> GetFavouritesForUser(int userId);
        int Update(int userId,UserDto dto);
    }
}
