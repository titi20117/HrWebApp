using HrWebApp.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class JobModel
    {
        [Display(Name = "Company Name")]
        [Required]
        public string CompanyId { get; set; } = null!;
        [Display(Name = "Job Title")]
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Responsibilities { get; set; }
        [Required]
        public List<int>? IdSkills { get; set; }
        [Display(Name = "Study Level")]
        [Required]
        public int StudyLevelId { get; set; }
        [Display(Name = "Working Experience")]
        [Required]
        public int WorkingExperience { get; set; }
        [Display(Name = "Working Hours (../week)")]
        public int WorkingHours { get; set; }

        [Display(Name = "Contract Name")]
        public int ContractId { get; set; }
        [Required]
        [Display(Name = "Salary (..$/h)")]
        public decimal Salary { get; set; }
        [Display(Name = "Job Description")]
        [Required]
        public string? Description { get; set; }
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get => DateTime.Now; }
        public List<Contract>? Contracts { get; set; }
        public List<Education>? StudyLevels { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
