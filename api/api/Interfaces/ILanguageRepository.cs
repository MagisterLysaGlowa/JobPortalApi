using api.Models;

namespace api.Interfaces
{
    public interface ILanguageRepository
    {
        object? GetLanguagesForUser(int userId);
        Language Insert(int userId, Language language);
        int Remove(int languageId);
        Language Update(int languageId, Language language);
    }
}
