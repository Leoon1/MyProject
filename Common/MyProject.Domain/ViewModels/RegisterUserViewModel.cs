using System.ComponentModel.DataAnnotations;

namespace MyProject.Domain.ViewModels
{
    public class RegisterUserViewModel
    {
        
        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Имя является обязательным")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 20 символов")]
        public string UserName { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пароль слишком простой")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 80 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтверждение пароля обязательно")]

        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Не совпадает с паролем")]
        public string PasswordConfirm { get; set; }
    }
}
