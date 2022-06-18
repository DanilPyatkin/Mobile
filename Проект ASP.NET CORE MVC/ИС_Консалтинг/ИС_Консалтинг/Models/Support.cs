using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ИС_Консалтинг.Models
{
    //модель тех поддержки
    public class Support
    {
        public int Id { get; set; }
        public User user { get; set; }

        [Required (ErrorMessage ="Заполните поле!")]
        [MinLength(10, ErrorMessage ="Некорректный вопрос!")]
        public string SMS { get; set; }
        public bool Active { get; set; }
    }
}
