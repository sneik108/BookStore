using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class UserView
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name ="Почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

       //если нужно, добавлю каптчу, доп. информацию....
    }
}