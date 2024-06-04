using api.Models;

namespace api.Interfaces
{
    public interface ICompanyRepository
    {
        Company Insert(Company company);
        Company Update(Company company);
        List<Company> GetAll();
        Company GetById(int companyId);
        Company GetCompanyForJobOfert(int jobOfertId);
        void DeleteCompany(int companyId);
        bool AddRelation(int companyId, int jobOfertId);
    }
}
