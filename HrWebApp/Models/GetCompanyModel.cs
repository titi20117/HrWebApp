namespace HrWebApp.Models
{
    public class GetCompanyModel
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int EmployeesCount { get; set; }
        public string? Description { get; set; }
        public List<GetCompanyModel>? Companies { get; set; }
    }
}
