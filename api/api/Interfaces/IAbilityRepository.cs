﻿using api.Models;

namespace api.Interfaces
{
    public interface IAbilityRepository
    {
        List<Ability> GetAbilitiesForUser(int userId);
        Ability Insert(int userId, Ability ability);
        int Remove(int abilityId);
        Ability Update(int abilityId, Ability ability);
    }
}
