using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.ClassOperation
{
    /// <summary>
    /// Класс считывания пользователей с бд
    /// </summary>
    public class List_User_DB
    {
        public  List<User> users { get; set; }
        public readonly string DBFilePathUser = ("DB\\user.txt");
        public JSON_operation<User> User_operation { get; set; }
        public List_User_DB()
        {
            User_operation = new JSON_operation<User>(DBFilePathUser);
            users = User_operation.ReadAllFromDB();
        }
    }
}
