namespace api.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseOrganizer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<UserCourse> UserCourses { get; } = [];
    }
}
