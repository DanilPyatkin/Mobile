using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ИС_Консалтинг.Models
{
    //объект пользователь для хранения в JSON файле
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(string Email, string Name, string Password)
        {
            this.Email = Email;
            this.Name = Name;
            this.Password = Password;
            this.Role = "User";
        }
    }
}
