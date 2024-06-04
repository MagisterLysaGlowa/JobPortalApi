using JobPortal.Api.Models;

namespace api.Interfaces
{
    public interface IBenefitRepository
    {
        Benefit Insert(int jobOfertId, Benefit benefit);
        List<Benefit> GetBenefits(int jobOfertId);
        void DeleteBenefit(int jobOfertId);
    }
}
