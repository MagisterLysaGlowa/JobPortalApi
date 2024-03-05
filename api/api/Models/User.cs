using System.Text.Json.Serialization;

namespace api.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        [JsonIgnore] public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthDate { get; set; }
        public string? AvatarSource { get; set; }
        public string? Domicile { get; set; }
        public string? Access { get; set; }
        public List<UserEducation> UserEducations { get; } = [];
        public List<UserExperience> UserExperiences { get; } = [];
        public List<UserCourse> UserCourses { get; } = [];
        public List<UserAbility> UserAbilities { get; } = [];
        public List<UserLanguage> UserLanguages { get; } = [];
        public List<UserLink> UserLinks { get; } = [];
    }
}
