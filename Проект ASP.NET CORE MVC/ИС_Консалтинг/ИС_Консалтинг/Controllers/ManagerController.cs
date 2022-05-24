using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ИС_Консалтинг.ClassOperation;
using ИС_Консалтинг.Models;

namespace ИС_Консалтинг.Controllers
{
    [Authorize (Roles = "Admin")]
    public class ManagerController : Controller
    {
        /// <summary>
        /// Создаю классы для считывания и хранения данных
        /// </summary>
        List_Mailing_DB mailing_DB;
        List_Support_DB support_DB;
        List_Bid_DB bid_DB;

        public ManagerController()
        {
            ///Считываю данные с JSON файлов
            mailing_DB = new List_Mailing_DB();
            support_DB = new List_Support_DB();
            bid_DB = new List_Bid_DB();
        }

        /// <summary>
        /// Передача данных с бд тех поддержки
        /// </summary>
        /// <returns></returns>
        public IActionResult Client_Support()
        {
            ViewBag.Message = "";
            return View(support_DB.supports);
        }


        /// <summary>
        /// Передача данных с бд заявок
        /// </summary>
        /// <returns></returns>
        public IActionResult Client_Bid()
        {
            ViewBag.Message = "";
            return View(bid_DB.bids);
        }


        //Обработанная заявка убирается со списка
        [HttpPost]
        public async Task<IActionResult> Client_Bid(int Id, string text)
        {
            if (text != null)
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(bid_DB.bids[Id].user.Email, bid_DB.bids[Id].service, text);


                bid_DB.bids[Id].active = false;
                bid_DB.Bid_operation.RemoveToDB(bid_DB.bids);
                return View(bid_DB.bids);
            }
            else
            {
                ViewBag.Message = "Введите текст для ответа";
                return View(bid_DB.bids);
            }
        }

        /// <summary>
        /// Передача данных с бд рассылок
        /// </summary>
        /// <returns></returns>
        public IActionResult Client_Mailing()
        {
            ViewBag.Message = "";
            return View(mailing_DB.mailings);
        }
        [HttpPost]
        public IActionResult Client_Mailing(int Id)
        {
            mailing_DB.mailings[Id].Active = false;
            mailing_DB.Mailing_operation.RemoveToDB(mailing_DB.mailings);
            return View(mailing_DB.mailings);
        }


        /// <summary>
        /// Рассылка всем пользователям активным
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Mailing(string Message)
        {
            if (Message != null)
            {
                foreach (var mailing in mailing_DB.mailings)
                {
                    if (mailing.Active == true)
                    {
                        EmailService emailService = new EmailService();
                        await emailService.SendEmailAsync(mailing.Email, "Консалтинговая компания MACON", Message);
                    }
                }
                return Redirect("../Home/HomePage");
            }
            else
            {
                ViewBag.Message = "Введите текст для рассылки";
                return Redirect("../Manager/Client_Mailing");
            }
        }


        /// <summary>
        /// Убираем отвеченный вопрос
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Client_Support(int Id, string text)
        {
            if (text != null)
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(bid_DB.bids[Id].user.Email, "Ответ на вопрос", text);
                support_DB.supports[Id].Active = false;
                support_DB.Support_operation.RemoveToDB(support_DB.supports);
                return View(support_DB.supports);
            }
            else
            {
                ViewBag.Message = "Введите ответ на вопрос";
                return View(support_DB.supports);
            }
        }
    }
}
