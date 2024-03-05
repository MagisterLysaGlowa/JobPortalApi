namespace api.Dtos
{
    public class ExperienceDto
    {
        public string? Proffesion { get; set; }
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserId { get; set; }
    }
}
