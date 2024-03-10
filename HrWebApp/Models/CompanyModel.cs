using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class CompanyModel
    {
        public string? Logo { get; set; }
        public string? Name { get; set; }
        public string? Sector { get; set; }
        public string? Type { get; set; }
        public int NumberOfEmployees { get; set; }
        public string? Location { get; set; }
        public int DateOfCreation { get; set; }
        public string? Description { get; set; }
        public string? UrlWebsite { get; set; }
    }
}
