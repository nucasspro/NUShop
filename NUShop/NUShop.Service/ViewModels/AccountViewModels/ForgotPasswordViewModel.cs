﻿using System.ComponentModel.DataAnnotations;

namespace NUShop.Service.ViewModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}