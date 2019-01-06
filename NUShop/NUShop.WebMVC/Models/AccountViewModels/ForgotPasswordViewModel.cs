using System.ComponentModel.DataAnnotations;

namespace NUShop.WebMVC.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}