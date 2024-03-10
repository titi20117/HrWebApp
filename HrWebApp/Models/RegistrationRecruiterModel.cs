using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class RegistrationRecruiterModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [Display(Name ="Company Type")]
        public string? CompanyType { get; set; }
        [Required]
        [Display(Name = "Company Size (number of employees)")]
        public int CompanyNumberOfEmployees { get; set; }
        [Required]
        [Display(Name = "Company Location")]
        public string? CompanyLocation { get; set; }
        [Required]
        [Display(Name = "Company Date Of Creation")]
        public int CompanyDateOfCreation { get; set; }
        [Required]
        [Display(Name = "Company Website")]
        public string? CompanyUrlWebsite { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string? CompanyPhoneNumber { get; set; }
        [Display(Name = "Company name")]
        public string? CompanyName { get; set; }
        [Display(Name = "Company Size")]
        public int CompanySize { get; set; }
        [Display(Name = "Company Industry")]
        public string? CompanyIndustry { get; set;}
        [Display(Name = "Company Description")]
        [DataType(DataType.MultilineText)]
        public string? CompanyDescription { get; set; }

    }
}
