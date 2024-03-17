using HrWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class UserAccountModel
    {
        [Display(Name="Email")]
        [Required]
        public string? UserEmail { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string UserPassword { get; set; } = null!;
        [Display(Name = "Password Confirmation")]
        [Required]
        public string UserConfirmationPassword { get; set; } = null!;
        [Display(Name = "Who are you?")]
        [Required]
        public int UserCategoryId { get; set; }
        public List<UserCategoryModel> UserCategoryList { get; set; }

    }
}
