using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public Course Insert(int userId, Course course)
        {
            _context.Courses.Add(course);
            var user = _context.Users.Find(userId);
            user?.UserCourses.Add(new UserCourse { Course = course });
            _context.SaveChanges();
            return course;
        }

        public int Remove(int courseId)
        {
            var course = _context.Courses.Find(courseId);
            if (course == null) return 0;
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return courseId;
        }

        public Course Update(int courseId, Course course)
        {
            var course_db = _context.Courses.Find(courseId);

            if (course_db == null) return null;

            course_db.CourseName = course.CourseName;
            course_db.CourseOrganizer = course.CourseOrganizer;
            course_db.StartDate = course.StartDate;
            course_db.EndDate = course.EndDate;


            _context.Courses.Update(course_db);
            _context.SaveChanges();
            return course_db;
        }
    }
}
