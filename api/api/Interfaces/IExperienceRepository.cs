using api.Models;

namespace api.Interfaces
{
    public interface IExperienceRepository
    {
        Experience Insert(int userId, Experience experience);
        int Remove(int experienceId);
        Experience Update(int experienceId, Experience experience);
    }
}
