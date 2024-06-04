using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using JobPortal.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace api.Repositories
{
    public class JobOfertRepository : IJobOfertRepository
    {
        private readonly AppDbContext _context;
        public JobOfertRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<JobOfert> GetAll()
        {
            var jobOferts = _context.JobOferts.ToList();
            return jobOferts;
        }

        public List<JobOfert> GetHomePageJobOferts(int pageNumber, FilterDto filter)
        {
            var filteredJobOferts = new List<JobOfert>();
            var jobOferts = _context.JobOferts.ToList();
            foreach (var ofert in jobOferts)
            {
                var company = _context.JobOfertCompany.Where(jc => jc.JobOfertId == ofert.Id).Select(c => c.Company).FirstOrDefault();
                var categories = _context.JobOfertCategory.Where(jc => jc.JobOfertId == ofert.Id).Select(c => c.Category).ToList();
                bool correct = true;

                //FILTER OPTIONS
                if (filter.PositionName != "")
                {
                    correct = ofert.PositionName!.ToLower().Contains(filter.PositionName!.ToLower());
                }
                if (filter.PositionLevel != "" && correct)
                {
                    correct = ofert.PositionLevel!.ToLower().Contains(filter.PositionLevel!.ToLower());
                }
                if (filter.EmploymentContract != "" && correct)
                {
                    correct = ofert.EmploymentContract!.ToLower().Contains(filter.EmploymentContract!.ToLower());
                }
                if (filter.EmploymentType != "" && correct)
                {
                    correct = ofert.EmploymentType!.ToLower().Contains(filter.EmploymentType!.ToLower());
                }
                if (filter.JobType != "" && correct)
                {
                    correct = ofert.JobType!.ToLower().Contains(filter.JobType!.ToLower());
                }
                if (filter.SalaryMinimum != 0 && correct)
                {
                    correct = ofert.SalaryMinimum >= filter.SalaryMinimum;
                }
                if (filter.SalaryMaximum != 0 && correct)
                {
                    correct = ofert.SalaryMaximum <= filter.SalaryMaximum;
                }
                if (filter.CompanyName != "" && correct)
                {
                    if (company != null)
                        correct = company!.CompanyName!.ToLower().Contains(filter.CompanyName!.ToLower());
                    else
                        correct = false;
                }
                if (filter.CompanyLocation != "" && correct)
                {
                    if (company != null)
                        correct = company!.CompanyLocation!.ToLower().Contains(filter.CompanyLocation!.ToLower());
                    else
                        correct = false;
                }

                if (filter.CategoryName != "" && correct)
                {
                    if (categories != null)
                        correct = categories.Any(c => c.CategoryName == filter.CategoryName);
                    else
                        correct = false;
                }
                if (correct)
                {
                    filteredJobOferts.Add(ofert);
                }
            }
            return filteredJobOferts.Skip(pageNumber * 10).Take(10).ToList();
        }

        public int GetAllJobOfertsFilter(FilterDto filter)
        {
            var filteredJobOferts = new List<JobOfert>();
            var jobOferts = _context.JobOferts.ToList();
            foreach (var ofert in jobOferts)
            {
                var company = _context.JobOfertCompany.Where(jc => jc.JobOfertId == ofert.Id).Select(c => c.Company).FirstOrDefault();
                var categories = _context.JobOfertCategory.Where(jc => jc.JobOfertId == ofert.Id).Select(c => c.Category).ToList();
                bool correct = true;

                //FILTER OPTIONS
                if (filter.PositionName != "")
                {
                    correct = ofert.PositionName!.ToLower().Contains(filter.PositionName!.ToLower());
                }
                if (filter.PositionLevel != "" && correct)
                {
                    correct = ofert.PositionLevel!.ToLower().Contains(filter.PositionLevel!.ToLower());
                }
                if (filter.EmploymentContract != "" && correct)
                {
                    correct = ofert.EmploymentContract!.ToLower().Contains(filter.EmploymentContract!.ToLower());
                }
                if (filter.EmploymentType != "" && correct)
                {
                    correct = ofert.EmploymentType!.ToLower().Contains(filter.EmploymentType!.ToLower());
                }
                if (filter.JobType != "" && correct)
                {
                    correct = ofert.JobType!.ToLower().Contains(filter.JobType!.ToLower());
                }
                if (filter.SalaryMinimum != 0 && correct)
                {
                    correct = ofert.SalaryMinimum >= filter.SalaryMinimum;
                }
                if (filter.SalaryMaximum != 0 && correct)
                {
                    correct = ofert.SalaryMaximum <= filter.SalaryMaximum;
                }
                if (filter.CompanyName != "" && correct)
                {
                    if (company != null)
                        correct = company!.CompanyName!.ToLower().Contains(filter.CompanyName!.ToLower());
                    else
                        correct = false;
                }
                if (filter.CompanyLocation != "" && correct)
                {
                    if (company != null)
                        correct = company!.CompanyLocation!.ToLower().Contains(filter.CompanyLocation!.ToLower());
                    else
                        correct = false;
                }

                if (filter.CategoryName != "" && correct)
                {
                    if (categories != null)
                        correct = categories.Any(c => c.CategoryName == filter.CategoryName);
                    else
                        correct = false;
                }
                if (correct)
                {
                    filteredJobOferts.Add(ofert);
                }
            }
            return filteredJobOferts.Count;
        }

        public JobOfert GetJobOfert(int jobOfertId)
        {
            var jobOfert = _context.JobOferts.Where(jo => jo.Id == jobOfertId).FirstOrDefault();
            return jobOfert;
        }

        public JobOfert Insert(JobOfert jobOfert)
        {
            try
            {
                jobOfert.CreatedAt = DateTime.Now;
                _context.JobOferts.Add(jobOfert);
                _context.SaveChanges();
                return jobOfert;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UpdateJobOfert(int jobOfertId, JobOfert jobOfert)
        {
            if(jobOfertId == jobOfert.Id)
            {
                _context.JobOferts.Update(jobOfert);
                _context.SaveChanges();
                Console.WriteLine("esasito");
            }
        }

        public void DeleteJobOfert(int jobOfertId)
        {
            var jobOfert = _context.JobOferts.Find(jobOfertId);
            _context.JobOferts.Remove(jobOfert);
            _context.SaveChanges();
        }
    }
}
