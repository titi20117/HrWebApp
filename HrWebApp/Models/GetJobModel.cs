namespace HrWebApp.Models
{
    public class GetJobModel
    {
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? JobContract { get; set; }
        public string? JobLocation { get; set; }
        public string? PublicationTime { get; set; }
        public List<GetJobModel>? Jobs { get; set; }
    }
}
