using api.Models;

namespace api.Interfaces
{
    public interface ILanguageRepository
    {
        Language Insert(int userId, Language language);
        int Remove(int languageId);
        Language Update(int languageId, Language language);
    }
}
