using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ИС_Консалтинг.ViewModels
{
    //View Model регистрации
    public class User_Registeration
    {
        [Required(ErrorMessage = "Заполните ФИО")]
        [MinLength(6,ErrorMessage ="Некорректное ФИО")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Введите Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Слишком короткий пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
