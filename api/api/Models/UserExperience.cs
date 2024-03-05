namespace api.Models
{
    public class UserExperience
    {
        public int UsersId { get; set; }
        public int ExperiencesId { get; set; }
        public User User { get; set; } = null!;
        public Experience Experience { get; set; } = null!;
    }
}
