using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ИС_Консалтинг.ViewModels
{
    //создал ViewModel аудентификации(валидация)
    public class User_Authorization
    {
        [Required(ErrorMessage = "Введите Еmail")]
        [EmailAddress(ErrorMessage = "Некорректный Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Слишком короткий пароль")]
        public string Password { get; set; }
    }
}
