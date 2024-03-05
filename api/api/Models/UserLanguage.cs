namespace api.Models
{
    public class UserLanguage
    {
        public int UsersId { get; set; }
        public int LanguagesId { get; set; }
        public User User { get; set; } = null!;
        public Language Language { get; set; } = null!;
    }
}
