using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public string SchoolName { get; set; }
        public string Location { get; set; }
        public string EducationLevel { get; set; }
        public string Field { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<UserEducation> UserEducations { get; } = [];
    }
}
