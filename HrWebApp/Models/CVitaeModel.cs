using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class CVitaeModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string? SurName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        public List<string>? Skills { get; set; }
        public string? Education { get; set; }
        [Display(Name = "Work Experience")]
        public int WorkExperience { get; set; }
        [Display(Name ="Number of Projects")]
        public int NumberOfProjects { get; set; }
        [Display(Name = "GitHub Profile")]
        [DataType(DataType.Url)]
        public string? GitHubProfile { get; set; }
        [Display(Name ="Awards and Honors")]
        public string? AwardsAndHonors { get; set; }
        public List<string>? Languages { get; set; }
        public string? Status { get; set; }
    }
}
