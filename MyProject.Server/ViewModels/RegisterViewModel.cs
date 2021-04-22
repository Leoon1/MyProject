using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Server.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email является обязательным")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Имя является обязательным")]
        [StringLength(15, ErrorMessage = "Длина поля {0} должна быть от {2} до {1} символов", MinimumLength = 2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пароль является обязательным")]
        [StringLength(80, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
