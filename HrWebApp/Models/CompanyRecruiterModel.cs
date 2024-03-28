namespace HrWebApp.Models
{
    public class CompanyRecruiterModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; }
        public string? Sector { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int JobCount { get; set; }
        public List<CompanyRecruiterModel>? CompanyRecruiters { get; set; }
        public List<GetJobModel>? Jobs { get; set; }
    }
}
