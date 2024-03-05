namespace api.Dtos
{
    public class CourseDto
    {
        public string? CourseName { get; set; }
        public string? CourseOrganizer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
