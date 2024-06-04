using System.Text.Json.Serialization;

namespace api.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthDate { get; set; }
        public string? Domicile { get; set; }
    }
}
