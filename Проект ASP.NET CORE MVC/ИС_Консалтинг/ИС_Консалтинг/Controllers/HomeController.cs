using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ИС_Консалтинг.ClassOperation;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.Controllers
{
    // контроллер, который представляет функции для неавторизированных пользователей
    public class HomeController : Controller
    {

        List_Mailing_DB mailing_DB;
        public HomeController()
        {
            mailing_DB = new List_Mailing_DB();
        }

        /// <summary>
        /// Подписка Email на новости
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Mailing(Mailing mailing)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var proverka = mailing_DB.mailings.Where(p => p.Email == mailing.Email).ToList();
                    if (proverka.Count > 0)
                    {
                        ModelState.AddModelError("Error", "Вы уже подписаны на новости");
                        return View();
                    }
                    else
                    {
                        EmailService emailService = new EmailService();
                        await emailService.SendEmailAsync(mailing.Email, "Консалтинговая компания Macon", "Вы успешно подписались на актуальные новости");
                        mailing.Id = mailing_DB.mailings.Count();
                        mailing.Active = true;
                        mailing_DB.Mailing_operation.SaveToDB(mailing);
                        mailing_DB.mailings = mailing_DB.Mailing_operation.ReadAllFromDB();
                        ViewBag.Message = "На вашу почту пришло письмо с подтверждение подписки";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                ModelState.AddModelError("Error", "Такого Email не существует");
                return View();
            }
        }
        


        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Mailing()
        {
            ViewBag.Message = "";
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
    }
}
