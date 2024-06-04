using api.Data;
using api.Interfaces;
using JobPortal.Api.Models;

namespace api.Repositories
{
    public class DutyRepository : IDutyRepository
    {
        private readonly AppDbContext _context;
        public DutyRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteDuty(int jobOfertId)
        {
            var duties = _context.JobOfertDuty.Where(jd => jd.JobOfertId == jobOfertId).Select(d => d.Duty).ToList();
            var dutiesRelations = _context.JobOfertDuty.Where(jd => jd.JobOfertId == jobOfertId).ToList();

            foreach (var item in dutiesRelations)
            {
                _context.JobOfertDuty.Remove(item);
            }
            foreach (var item in duties)
            {
                _context.Duty.Remove(item);
            }
            _context.SaveChanges();
        }

        public List<Duty> GetDuties(int jobOfertId)
        {
            var duties = _context.JobOfertDuty.Where(jd => jd.JobOfertId == jobOfertId).Select(d => d.Duty).ToList();
            return duties;
        }

        public Duty Insert(int jobOfertId, Duty duty)
        {
            _context.Duty.Add(duty);
            var user = _context.JobOferts.Find(jobOfertId);
            user?.JobOfertDuties.Add(new JobOfertDuty { Duty = duty });
            _context.SaveChanges();
            return duty;
        }
    }
}
