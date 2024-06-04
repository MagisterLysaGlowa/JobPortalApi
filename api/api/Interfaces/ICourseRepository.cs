using api.Models;

namespace api.Interfaces
{
    public interface ICourseRepository
    {
        Course Insert(int userId, Course course);
        int Remove(int courseId);
        Course Update(int courseId, Course course);
        List<Course> GetAll();
        List<Course> GetCoursesForUser(int userId);
    }
}
