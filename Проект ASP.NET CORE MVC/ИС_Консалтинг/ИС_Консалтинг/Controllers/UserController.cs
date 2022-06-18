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
       private List_Object_DB<User> user_DB;
       private List_Object_DB<Support> support_DB;
       private List_Object_DB<Bid> bid_DB;
        public UserController()
        {
            ///Считываю данные из файла JSON
            user_DB = new List_Object_DB<User>("DB\\user.txt");
            support_DB = new List_Object_DB<Support>("DB\\Support.txt");
            bid_DB = new List_Object_DB<Bid>("DB\\Bid.txt");
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
        /// Оформление заявки
        /// </summary>
        [HttpPost]
        public IActionResult Bid(Bid bid)
        {
            if (ModelState.IsValid)
            {
                bid.Id = bid_DB.Objects.Count();
                bid.active = true;
                bid.user = user_DB.Objects.Where(p => p.Email == HttpContext.User.Identity.Name).First();
                bid_DB.Object_operation.SaveToDB(bid);
                ViewBag.Message = "Заявка успешно заказана!";
                return View();
            }
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
                support.Id = support_DB.Objects.Count();
                support.user = user_DB.Objects.Where(p => p.Email == HttpContext.User.Identity.Name).First();
                support_DB.Object_operation.SaveToDB(support);
                ViewBag.Message = "Ваш вопрос отправлен!";
                return View();
            }
            return View();
        }
    }
}
