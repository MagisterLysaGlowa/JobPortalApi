namespace api.Models
{
    public class UserAbility
    {
        public int UsersId { get; set; }
        public int AbilitiesId { get; set; }
        public User User { get; set; } = null!;
        public Ability Ability { get; set; } = null!;
    }
}
