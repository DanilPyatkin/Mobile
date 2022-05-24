using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.ClassOperation
{
    /// <summary>
    /// Класс считывания рассылок с бд
    /// </summary>
    public class List_Mailing_DB
    {
        public List<Mailing> mailings { get; set; }
        public readonly string DBFilePathMailing = ("DB\\Mailing.txt");
        public JSON_operation<Mailing> Mailing_operation { get; set; }
        public List_Mailing_DB()
        {
            Mailing_operation = new JSON_operation<Mailing>(DBFilePathMailing);
            mailings = Mailing_operation.ReadAllFromDB();
        }
    }
}
