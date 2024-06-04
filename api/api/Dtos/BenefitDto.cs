using JobPortal.Api.Models;

namespace api.Dtos
{
    public class BenefitDto
    {
        public int JobOfertId { get; set; }
        public string[] Benefits { get; set; }
    }
}
