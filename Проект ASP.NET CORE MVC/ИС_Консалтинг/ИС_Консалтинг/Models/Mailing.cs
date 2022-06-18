using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ИС_Консалтинг.Models
{
    // модель рассылки
    public class Mailing
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Заполните поле!")]
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
