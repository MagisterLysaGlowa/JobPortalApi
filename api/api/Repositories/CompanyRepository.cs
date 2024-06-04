using api.Data;
using api.Interfaces;
using api.Models;
using JobPortal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;
        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool AddRelation(int companyId, int jobOfertId)
        {
            try
            {
                JobOfert? jobOfert = _context.JobOferts.Where(jo => jo.Id == jobOfertId).FirstOrDefault();
                Company? company = _context.Company.Where(c => c.CompanyId == companyId).FirstOrDefault();
                jobOfert?.JobOfertCompany.Add(new JobOfertCompany { Company = company });
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void DeleteCompany(int companyId)
        {
            var company = _context.Company.Find(companyId);
            var jobOferts = _context.JobOfertCompany.Where(jc => jc.CompanyId == companyId).Select(jc => jc.JobOfert).ToList();
            foreach(var jobOfert in jobOferts)
            {
                _context.JobOferts.Remove(jobOfert);
            }
            _context.Company.Remove(company!);
            _context.SaveChanges();
        }

        public List<Company> GetAll()
        {
            var companies = _context.Company.ToList();
            return companies;
        }

        public Company GetById(int companyId)
        {
            var company = _context.Company.FirstOrDefault(c => c.CompanyId == companyId);
            return company;
        }

        public Company GetCompanyForJobOfert(int jobOfertId)
        {
            var company = _context.JobOfertCompany.Where(jc => jc.JobOfertId == jobOfertId).Select(c => c.Company).FirstOrDefault();
            return company;
        }

        public Company Insert(Company company)
        {
            try
            {
                _context.Company.Add(company);
                _context.SaveChanges();
                return company;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Company Update(Company company)
        {
            _context.Company.Update(company);
            _context.SaveChanges();
            return company;
        }
    }
}
