using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class RegistrationStudentModel
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
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required]
        [MinLength(7)]
        [DataType(DataType.Password)]
        public string? PassWord { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        public string? PasswordConfirmation { get; set; }
    }
}
