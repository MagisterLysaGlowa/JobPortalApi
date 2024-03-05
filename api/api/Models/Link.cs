namespace api.Models
{
    public class Link
    {
        public int LinkId { get; set; }
        public string? LinkContent { get; set; }
        public List<UserLink> UserLinks { get; } = [];
    }
}
