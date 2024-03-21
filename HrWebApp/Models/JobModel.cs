using HrWebApp.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class JobModel
    {
        [Display(Name ="Company Name")]
        public int CompanyId { get; set; }
        [Display(Name = "Job Title")]
        public string? Title { get; set; }
        public string? Responsibilities { get; set; }
        public int SkillId { get; set; }
        [Display(Name = "Study Level")]
        public int StudyLevelId { get; set; }
        [Display(Name = "Working Experience")]
        public int WorkingExperience { get; set; }
        [Display(Name = "Working Hours")]
        public int WorkingHours { get; set; }
        [Display(Name = "Contract Name")]
        public int ContractId { get; set; }
        public decimal Salary { get; set; }
        public string? Location { get; set; }
        [Display(Name = "Company Culture")]
        public string? Description { get; set; }
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get => DateTime.Now; }
        public List<Contract>? Contracts { get; set; }
        public List<Education>? StudyLevels { get; set; }
        public List<Skill>? Skills { get; set; }
        
    }
}
