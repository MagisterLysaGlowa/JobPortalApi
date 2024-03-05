namespace api.Dtos
{
    public class EducationDto
    {
        public string SchoolName { get; set; }
        public string Location { get; set; }
        public string EducationLevel { get; set; }
        public string Field { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
