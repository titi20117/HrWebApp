using HrWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class CompanyModel
    {
        [Display(Name = "Recruiter First Name")]
        [Required]
        public string CompanyRecruiterFirstName { get; set; } = null!;
        [Display(Name = "Recruiter Last Name")]
        [Required]
        public string CompanyRecruiterLastName { get; set; } = null!;
        [Display(Name = "Recruiter Mail")]
        [Required]
        public string UserMail { get; set; } = null!;
        [Display(Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; } = null!;
        [Display(Name = "Company sector activity")]
        public int CompanySectorId { get; set; }
        [Display(Name = "Company Type")]
        public int CompanyTypeId { get; set; }
        [Display(Name = "Company phone")]
        [Required]
        public string CompanyPhone { get; set; } = null!;
        [Display(Name = "Number of employees")]
        public int CompanyNumberOfEmployees { get; set; }
        [Display(Name = "Company Location (ex. Russia, 60 Gagarina street")]
        [Required]
        public string CompanyLocation { get; set; } = null!;
        [Display(Name = "Date creation of the company")]
        public int CompanyDateOfCreation { get; set; }
        [Display(Name = "About Company")]
        public string CompanyDescription { get; set; } = null!;
        [Display(Name = "Site Web")]
        public string CompanyUrl { get; set; } = null!;
        public List<CompanySector>? CompanySectors { get; set; }
        public List<CompanyType>? CompanyTypes { get; set; }
        public List<Company>? Companies { get; set; }
        public List<User>? Users { get; set; }
        public User MyUser { get; set; }
        public CompanySector MyCompanySector { get; set; }
        public CompanyType MyCompanyType { get; set; }
    }
}
