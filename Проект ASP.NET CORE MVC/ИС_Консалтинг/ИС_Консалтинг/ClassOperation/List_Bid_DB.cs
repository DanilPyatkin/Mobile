using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.ClassOperation
{
    /// <summary>
    /// Класс считывания всех заявок с бд
    /// </summary>
    public class List_Bid_DB
    {
        public List<Bid> bids { get; set; }
        public readonly string DBFilePathBid = ("DB\\Bid.txt");
        public JSON_operation<Bid> Bid_operation { get; set; }
        public List_Bid_DB()
        {
            Bid_operation = new JSON_operation<Bid>(DBFilePathBid);
            bids = Bid_operation.ReadAllFromDB();
        }
    }
}
