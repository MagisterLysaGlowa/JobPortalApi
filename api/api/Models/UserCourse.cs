namespace api.Models
{
    public class UserCourse
    {
        public int UsersId { get; set; }
        public int CoursesId { get; set; }
        public User User { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
