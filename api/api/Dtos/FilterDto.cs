namespace api.Dtos
{
    public class FilterDto
    {
        public string? PositionName { get; set; }
        public string? PositionLevel { get; set; }
        public string? EmploymentContract { get; set; }
        public string? EmploymentType { get; set; }
        public string? JobType { get; set; }
        public decimal? SalaryMinimum { get; set; }
        public decimal? SalaryMaximum { get; set; }

        public string? CompanyName { get; set; }
        public string? CompanyLocation { get; set; }
        public string? CategoryName { get; set; }
    }
}
