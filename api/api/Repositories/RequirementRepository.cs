using api.Data;
using api.Interfaces;
using api.Models;
using JobPortal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly AppDbContext _context;
        public RequirementRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteRequirement(int jobOfertId)
        {
            var requirements = _context.JobOfertRequirement.Where(jr => jr.JobOfertId == jobOfertId).Select(r => r.Requirement).ToList();
            var requirementsRelations = _context.JobOfertRequirement.Where(jr => jr.JobOfertId == jobOfertId).ToList();

            foreach (var item in requirementsRelations)
            {
                _context.JobOfertRequirement.Remove(item);
            }
            foreach (var item in requirements)
            {
                _context.Requirement.Remove(item);
            }
            _context.SaveChanges();
        }

        public List<Requirement> GetRequirements(int jobOfertId)
        {
            var requirements = _context.JobOfertRequirement.Where(jr => jr.JobOfertId == jobOfertId).Select(r => r.Requirement).ToList();
            return requirements;
        }

        public Requirement Insert(int jobOfertId, Requirement requirement)
        {
            _context.Requirement.Add(requirement);
            var user = _context.JobOferts.Find(jobOfertId);
            user?.JobOfertRequirements.Add(new JobOfertRequirement { Requirement = requirement });
            _context.SaveChanges();
            return requirement;
        }
    }
}
