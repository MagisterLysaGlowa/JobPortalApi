using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class AbilityRepository : IAbilityRepository
    {
        private readonly AppDbContext _context;
        public AbilityRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Ability> GetAbilitiesForUser(int userId)
        {
            var abilities = _context.UserAbilities.Where(ua => ua.UsersId == userId).Select(ua => ua.Ability).ToList();
            return abilities;
        }

        public Ability Insert(int userId, Ability ability)
        {
            _context.Abilities.Add(ability);
            var user = _context.Users.Find(userId);
            user?.UserAbilities.Add(new UserAbility { Ability = ability });
            _context.SaveChanges();
            return ability;
        }

        public int Remove(int abilityId)
        {
            var ability = _context.Abilities.Find(abilityId);
            if (ability == null) return 0;
            _context.Abilities.Remove(ability);
            _context.SaveChanges();
            return abilityId;
        }

        public Ability Update(int abilityId, Ability ability)
        {
            var ability_db = _context.Abilities.Find(abilityId);

            if (ability_db == null) return null;

            ability_db.AbilityName = ability.AbilityName;

            _context.Abilities.Update(ability_db);
            _context.SaveChanges();
            return ability_db;
        }
    }
}
