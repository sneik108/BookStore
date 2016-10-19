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
        [Display(Name ="Почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

       //если нужно, добавлю каптчу, доп. информацию....
    }
}