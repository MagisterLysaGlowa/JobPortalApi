namespace api.Models
{
    public class Ability
    {
        public int AbilityId { get; set; }
        public string? AbilityName { get; set; }
        public List<UserAbility> UserAbilities { get; } = [];
    }
}
