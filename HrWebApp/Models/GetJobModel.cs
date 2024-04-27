using HrWebApp.Data;

namespace HrWebApp.Models
{
    public class GetJobModel
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int CompanyNbrEmployees { get; set; }
        public string? JobTitle { get; set; }
        public string? JobContract { get; set; }
        public string? JobLocation { get; set; }
        public DateTime PublicationTime { get; set; }
        public List<string>? Responsibilities { get; set; }
        public string? StudyLevel { get; set; }
        public int WorkingExperience { get; set; }
        public int WorkingHours { get; set; }
        public decimal Salary { get; set; }
        public string? Description { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<GetJobModel>? Jobs { get; set; }
    }
}
