using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(256)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember")]
        public bool RememberMe { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}
