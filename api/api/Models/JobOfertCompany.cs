using JobPortal.Api.Models;

namespace api.Models
{
    public class JobOfertCompany
    {
        public int JobOfertId { get; set; }
        public int CompanyId { get; set; }
        public JobOfert? JobOfert { get; set; }
        public Company? Company { get; set; }
    }
}
