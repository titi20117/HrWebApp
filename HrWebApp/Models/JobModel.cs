using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class JobModel
    {
        public string? Title { get; set; }
        public string? Responsibilities { get; set; }
        public List<string>? Skills { get; set; }
        [Display(Name = "Study Level")]
        public string? StudyLevel { get; set; }
        [Display(Name = "Working Experience")]
        public int WorkingExperience { get; set; }
        [Display(Name = "Working Hours")]
        public int WorkingHours { get; set; }
        public string? Contract { get; set; }
        public decimal Salary { get; set; }
        public string? Location { get; set; }
        [Display(Name = "Company Culture")]
        public string? Description { get; set; }
        public DateTime PublicationDate { get => DateTime.Now; }
    }
}
