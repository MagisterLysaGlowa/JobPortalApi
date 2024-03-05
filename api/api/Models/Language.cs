namespace api.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageLevel { get; set; }
        public List<UserLanguage> UserLanguages { get; } = [];
    }
}
