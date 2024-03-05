namespace api.Models
{
    public class UserLink
    {
        public int UsersId { get; set; }
        public int LinksId { get; set; }
        public User User { get; set; } = null!;
        public Link Link { get; set; } = null!;
    }
}
