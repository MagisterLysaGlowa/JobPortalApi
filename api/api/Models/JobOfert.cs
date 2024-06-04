using api.Models;

namespace JobPortal.Api.Models
{
    public class JobOfert
    {
        public int Id { get; set; }
        public DateTime RecruitmentEndDate { get; set; }
        public string? PositionName { get; set; }   
        public string? PositionLevel { get; set; }   
        public string? EmploymentContract { get; set; }   
        public string? EmploymentType { get; set; }   
        public string? JobType { get; set; }   
        public decimal? SalaryMinimum { get; set; }   
        public decimal? SalaryMaximum { get; set; }   
        public string? WorkDays { get; set; }   
        public string? WorkStartHour { get; set; }   
        public string? WorkEndHour { get; set; }   
        public DateTime? CreatedAt { get; set; }   

        public List<JobOfertCategory> JobOfertCategories { get; set; } = new();
        public List<JobOfertDuty> JobOfertDuties { get; set; } = new();
        public List<JobOfertRequirement> JobOfertRequirements { get; set; } = new();
        public List<JobOfertBenefit> JobOfertBenefits { get; set; } = new();
        public List<UserJobOfert> UserJobOferts { get; set; } = new();
        public List<UserJobOfertApplication> UserJobOfertsApplications { get; set; } = new();
        public List<UserJobOfertFavourite> UserJobOfertsFavourites { get; set; } = new();
        public List<JobOfertCompany> JobOfertCompany { get; set; } = new();

    }
}
