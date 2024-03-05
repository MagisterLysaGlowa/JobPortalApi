using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _context;
        public LanguageRepository(AppDbContext context)
        {
            _context = context;
        }
        public Language Insert(int userId, Language language)
        {
            _context.Languages.Add(language);
            var user = _context.Users.Find(userId);
            user?.UserLanguages.Add(new UserLanguage { Language = language });
            _context.SaveChanges();
            return language;
        }

        public int Remove(int languageId)
        {
            var language = _context.Languages.Find(languageId);
            if (language == null) return 0;
            _context.Languages.Remove(language);
            _context.SaveChanges();
            return languageId;
        }

        public Language Update(int languageId, Language language)
        {
            var language_db = _context.Languages.Find(languageId);

            if (language_db == null) return null;

            language_db.LanguageName = language.LanguageName;
            language_db.LanguageLevel = language.LanguageLevel;

            _context.Languages.Update(language_db);
            _context.SaveChanges();
            return language_db;
        }
    }
}
