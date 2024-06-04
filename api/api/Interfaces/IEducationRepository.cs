using api.Models;

namespace api.Interfaces
{
    public interface IEducationRepository
    {
        Education Insert(int userId,Education education);
        int Remove(int educationId);
        Education Update(int educationId, Education education);
        List<Education> GetAll();
        List<Education> GetEducationsForUser(int userId);
    }
}
