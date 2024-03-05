namespace api.Models
{
    public class UserEducation
    {
        public int UsersId { get; set; }
        public int EducationsId { get; set; }
        public User User { get; set; } = null!;
        public Education Education { get; set; } = null!;
    }
}
