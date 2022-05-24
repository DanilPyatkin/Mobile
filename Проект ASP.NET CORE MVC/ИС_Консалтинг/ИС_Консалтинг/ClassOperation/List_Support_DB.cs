using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.ClassOperation
{
    /// <summary>
    /// Класс считывания вопросов пользователей с бд
    /// </summary>
    public class List_Support_DB
    {
        public List<Support> supports { get; set; }
        public readonly string DBFilePathSupport = ("DB\\Support.txt");
        public JSON_operation<Support> Support_operation { get; set; }
        public List_Support_DB()
        {
            Support_operation = new JSON_operation<Support>(DBFilePathSupport);
            supports = Support_operation.ReadAllFromDB();
        }
    }
}
