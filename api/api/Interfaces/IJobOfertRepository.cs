using api.Dtos;
using api.Models;
using JobPortal.Api.Models;

namespace api.Interfaces
{
    public interface IJobOfertRepository
    {
        JobOfert Insert(JobOfert jobOfert);
        List<JobOfert> GetAll();
        JobOfert GetJobOfert(int jobOfertId);
        List<JobOfert> GetHomePageJobOferts(int pageNumber, FilterDto filter);
        int GetAllJobOfertsFilter(FilterDto filter);
        void UpdateJobOfert(int jobOfertId, JobOfert jobOfert);
        void DeleteJobOfert(int jobOfertId);
    }
}
