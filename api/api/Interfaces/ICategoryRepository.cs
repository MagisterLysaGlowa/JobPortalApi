using JobPortal.Api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Category Insert(int jobOfertId,Category category);
        List<Category> GetAll();
        List<Category> GetCategoryByJobId(int jobOfertId);
        bool CheckCategoryInDb(Category category);
        void DeleteCategory(int jobOfertId);
    }
}
