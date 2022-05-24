using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ИС_Консалтинг.ClassOperation;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.Controllers
{
    //контроллер, который представляет функции оставления заявки и вопросы по заявкам для авторизированных пользователей
    [Authorize]
    public class UserController : Controller
    {
        /// <summary>
        /// Создаю классы для считывания и хранения данных
        /// </summary>
        List_User_DB user_DB;

        List_Support_DB support_DB;

        List_Bid_DB bid_DB;


        public UserController()
        {
            ///Считываю данные из файла JSON
            user_DB = new List_User_DB();
            support_DB = new List_Support_DB();
            bid_DB = new List_Bid_DB();
        }


        /// <summary>
        /// Оформление заявки
        /// </summary>
        [HttpPost]
        public IActionResult Bid(Bid bid)
        {
            if (ModelState.IsValid)
            {
                bid.Id = bid_DB.bids.Count();
                bid.active = true;
                bid.user = user_DB.users.Where(p => p.Email == HttpContext.User.Identity.Name).First();
                bid_DB.Bid_operation.SaveToDB(bid);
                ViewBag.Message = "Заявка успешно заказана!";
                return View();
            }
            return View();
        }

        public IActionResult Bid()
        {
            ViewBag.Messade = "";
            return View();
        }
        public IActionResult Support()
        {
            ViewBag.Messade = "";
            return View();
        }

        /// <summary>
        /// Оформление вопроса
        /// </summary>
        [HttpPost]
        public IActionResult Support(Support support)
        {
            if (ModelState.IsValid)
            {
                support.Active = true;
                support.Id = support_DB.supports.Count();
                support.user = user_DB.users.Where(p => p.Email == HttpContext.User.Identity.Name).First();
                support_DB.Support_operation.SaveToDB(support);
                ViewBag.Message = "Ваш вопрос отправлен!";
                return View();
            }
            return View();
        }
    }
}
