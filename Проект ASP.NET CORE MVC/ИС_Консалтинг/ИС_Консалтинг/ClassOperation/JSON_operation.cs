using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.ClassOperation
{
    //класс для работы с JSON файлом
    public class JSON_operation<T> where T : class
    {
        private readonly string exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
        private string DBFilePath { get; set; }

        //конструктор передаем путь к файлу
        public JSON_operation(string DBFilePath)
        {
            this.DBFilePath = Path.Combine(this.exePath, DBFilePath);
        }

        //считывание с файла
        public List<T> ReadAllFromDB()
        {
            string json = File.ReadAllText(this.DBFilePath);

            List<T> current = JsonConvert.DeserializeObject<List<T>>(json);

            return current ?? new List<T>();
        }

        //Сохранение в файл
        public void SaveToDB(T data)
        {
            List<T> allCurrent = this.ReadAllFromDB();
            allCurrent.Add(data);
            string serializedUsers = JsonConvert.SerializeObject(allCurrent);
            File.WriteAllText(DBFilePath, serializedUsers);
        }

        public void RemoveToDB(List<T> allCurrent)
        {
            string serializedUsers = JsonConvert.SerializeObject(allCurrent);
            File.WriteAllText(DBFilePath, serializedUsers);
        }
    }
}
