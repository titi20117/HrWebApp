namespace HrWebApp.Models
{
    public class GetCompanyModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CompanySector { get; set; }
        public string? Type { get; set; }
        public string CompanyPhone { get; set; } = null!;
        public int EmployeesCount { get; set; }
        public string CompanyLocation { get; set; } = null!;
        public int CompanyDateOfCreation { get; set; }
        public string? Description { get; set; }
        public string CompanyUrl { get; set; } = null!;
        public List<GetCompanyModel>? Companies { get; set; }
        public List<GetJobModel>? Jobs { get; set; }
    }
}
