namespace api.Dtos
{
    public class JobOfertDto
    {
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
    }
}
