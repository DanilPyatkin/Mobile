using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.ClassOperation
{
    /// <summary>
    /// класс для записи объектов T в JSON фаил
    /// </summary>
    public class List_Object_DB<T>
        where T : class
    {
        public List<T> Objects { get; set; }
        private readonly string DBFilePath;
        public JSON_operation<T> Object_operation { get; set; }
        public List_Object_DB(string DBFilePath)
        {
            this.DBFilePath = DBFilePath;
            Object_operation = new JSON_operation<T>(this.DBFilePath);
            Objects = Object_operation.ReadAllFromDB();
        }
    }
}
