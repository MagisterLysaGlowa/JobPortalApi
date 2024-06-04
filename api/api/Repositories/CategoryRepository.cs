using api.Data;
using api.Interfaces;
using JobPortal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CheckCategoryInDb(Category category)
        {
            bool any = _context.Category.Any(c => c.CategoryName == category.CategoryName);
            return any;
        }

        public void DeleteCategory(int jobOfertId)
        {
            var category = _context.JobOfertCategory.Where(jc => jc.JobOfertId == jobOfertId).Select(c => c.Category).FirstOrDefault();
            var categoriesRelations = _context.JobOfertCategory.Where(jc => jc.JobOfertId == jobOfertId).ToList();

            foreach (var item in categoriesRelations)
            {
                var allRelations = _context.JobOfertCategory.Where(jc => jc.CategoryId == item.CategoryId).ToList();
                Console.WriteLine("all realtions: " + allRelations.Count);
                _context.JobOfertCategory.Remove(item);
                if (allRelations.Count < 2)
                {
                    _context.Category.Remove(category);
                }
            }
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            var categories = _context.Category.ToList();
            return categories;
        }

        public List<Category> GetCategoryByJobId(int jobOfertId)
        {
            var categories = _context.JobOfertCategory.Where(jc => jc.JobOfertId == jobOfertId).Select(c => c.Category).ToList();
            return categories;
        }

        public Category Insert(int jobOfertId, Category category)
        {
            if(CheckCategoryInDb(category))
            {
                var jobOfert = _context.JobOferts.Find(jobOfertId);
                Category? categoryInDb = _context.Category.Where(c => c.CategoryName == category.CategoryName).FirstOrDefault();
                jobOfert?.JobOfertCategories.Add(new JobOfertCategory { Category = categoryInDb });
                _context.SaveChanges();
            }
            else
            {
                _context.Category.Add(category);
                var jobOfert = _context.JobOferts.Find(jobOfertId);
                jobOfert?.JobOfertCategories.Add(new JobOfertCategory { Category = category });
                _context.SaveChanges();

            }
            return category;
        }
    }
}
