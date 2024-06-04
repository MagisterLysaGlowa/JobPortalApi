using JobPortal.Api.Models;

namespace api.Interfaces
{
    public interface IDutyRepository
    {
        Duty Insert(int jobOfertId,Duty duty);
        List<Duty> GetDuties(int jobOfertId);
        void DeleteDuty(int jobOfertId); 
    }
}
