using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class LoginModel
    {
        [Required]
        public string? Mail { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
