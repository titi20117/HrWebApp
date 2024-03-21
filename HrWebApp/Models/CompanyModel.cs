using HrWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class CompanyModel
    {
        public string CompanyRecruiterFirstName { get; set; } = null!;
        public string CompanyRecruiterLastName { get; set; } = null!;
        [Display(Name = "Recruiter Email")]
        public int UserId { get; set; }
        public string? CompanyName { get; set; }
        public int CompanySectorId { get; set; }
        public int CompanyTypeId { get; set; }
        public string CompanyPhone { get; set; } = null!;
        public int CompanyNumberOfEmployees { get; set; }
        public string? CompanyLocation { get; set; }
        public int CompanyDateOfCreation { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyUrl { get; set; }
        public List<CompanySector>? CompanySectors { get; set; }
        public List<CompanyType>? CompanyTypes { get; set; }
    }
}
