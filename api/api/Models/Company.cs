namespace api.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyLocation { get; set; }
        public string? CompanyDescription { get; set; }
        public List<JobOfertCompany> JobOfertCompany { get; set; } = new();
    }
}
