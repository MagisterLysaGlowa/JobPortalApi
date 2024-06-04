using JobPortal.Api.Models;

namespace api.Interfaces
{
    public interface IRequirementRepository
    {
        Requirement Insert(int jobOfertId, Requirement requirement);
        List<Requirement> GetRequirements(int jobOfertId); 
        void DeleteRequirement(int jobOfertId);
    }
}
