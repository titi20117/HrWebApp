using HrWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class StudentModel
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
        [MaxLength(50)]
        [Display(Name = "Email Address")]
        public string UserMail { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Skills")]
        public List<int>? SkillsId { get; set; }
        [Display(Name = "Educations")]
        public List<int>? EducationsId { get; set; }
        [Display(Name = "Work Experience")]
        public int WorkExperience { get; set; }
        [Display(Name ="Number of Projects")]
        public int NumberOfProjects { get; set; }
        [Display(Name = "GitHub Profile")]
        [DataType(DataType.Url)]
        public string? GitHubProfile { get; set; }
        [Display(Name ="Awards and Honors")]
        public string? AwardsAndHonors { get; set; }
        [Display(Name = "Languages")]
        public List<int>? LanguagesId { get; set; }
        [Display(Name = "Status")]
        public int StatutId { get; set; }
        [Display(Name = "Education Average Score")]
        public double EducationAverageScore { get; set; }
        public List<StudentStatus>? Status { get; set; }
        public List<Language>? Languages { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<Education>? Educations { get; set; }
        public List<Vacancy>? Vacancies { get; set; }
    }
}
