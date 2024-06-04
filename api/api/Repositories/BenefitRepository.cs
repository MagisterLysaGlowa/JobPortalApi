using api.Data;
using api.Interfaces;
using JobPortal.Api.Models;

namespace api.Repositories
{
    public class BenefitRepository : IBenefitRepository
    {
        private readonly AppDbContext _context;
        public BenefitRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteBenefit(int jobOfertId)
        {
            var benefits = _context.JobOfertBenefit.Where(jb => jb.JobOfertId == jobOfertId).Select(b => b.Benefit).ToList();
            var benefitsRelations = _context.JobOfertBenefit.Where(jb => jb.JobOfertId == jobOfertId).ToList();

            foreach (var item in benefitsRelations)
            {
                _context.JobOfertBenefit.Remove(item);
            }
            foreach (var item in benefits)
            {
                _context.Benefit.Remove(item);
            }
            _context.SaveChanges();
        }

        public List<Benefit> GetBenefits(int jobOfertId)
        {
            var benefits = _context.JobOfertBenefit.Where(jb => jb.JobOfertId == jobOfertId).Select(b => b.Benefit).ToList();
            return benefits;
        }

        public Benefit Insert(int jobOfertId, Benefit benefit)
        {
            _context.Benefit.Add(benefit);
            var user = _context.JobOferts.Find(jobOfertId);
            user?.JobOfertBenefits.Add(new JobOfertBenefit { Benefit = benefit });
            _context.SaveChanges();
            return benefit;
        }
    }
}
