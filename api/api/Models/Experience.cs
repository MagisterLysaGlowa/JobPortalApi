namespace api.Models
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string? Proffesion { get; set; }
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<UserExperience> UserExperiences { get; } = [];
    }
}
