using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ИС_Консалтинг.Models
{
    //Модель заявки
    public class Bid
    {
        public int Id { get; set; }
        public User user { get; set; }

        [Required(ErrorMessage ="Выберите услугу!")]
        public string service { get; set; }
        public bool active { get; set; }
    }
}
