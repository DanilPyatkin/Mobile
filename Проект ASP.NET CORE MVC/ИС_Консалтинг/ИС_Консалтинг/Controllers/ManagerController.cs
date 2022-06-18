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
       private List_Object_DB<Mailing> mailing_DB;
       private List_Object_DB<Support> support_DB;
       private List_Object_DB<Bid> bid_DB;
        public ManagerController()
        {
            ///Считываю данные с JSON файлов
            mailing_DB = new List_Object_DB<Mailing>("DB\\Mailing.txt");
            support_DB = new List_Object_DB<Support>("DB\\Support.txt");
            bid_DB = new List_Object_DB<Bid>("DB\\Bid.txt");
        }

        /// <summary>
        /// Передача данных с бд тех поддержки
        /// </summary>
        /// <returns></returns>
        public IActionResult Client_Support()
        {
            ViewBag.Message = "";
            return View(support_DB.Objects);
        }

        /// <summary>
        /// Передача данных с бд заявок
        /// </summary>
        /// <returns></returns>
        public IActionResult Client_Bid()
        {
            ViewBag.Message = "";
            return View(bid_DB.Objects);
        }

        /// <summary>
        /// Передача данных с бд рассылок
        /// </summary>
        /// <returns></returns>
        public IActionResult Client_Mailing()
        {
            ViewBag.Message = "";
            return View(mailing_DB.Objects);
        }

        /// <summary>
        /// Убираем из рассылок неактивного пользователя
        /// </summary>
        [HttpPost]
        public IActionResult Client_Mailing(int Id)
        {
            mailing_DB.Objects[Id].Active = false;
            mailing_DB.Object_operation.RemoveToDB(mailing_DB.Objects);
            return View(mailing_DB.Objects);
        }

        /// <summary>
        /// Переходим на страницу обработки заявки-пользователя с id
        /// </summary>
        [HttpGet]
        public IActionResult Client_Response_Bid(int id)
        {
          
            return View(id);
        }

        /// <summary>
        /// Переходим на страницу ответа на вопрос пользователя с id
        /// </summary>
        [HttpGet]
        public IActionResult Client_Response_Support(int id)
        {

            return View(id);
        }

        public IActionResult Client_Response_Mailing()
        {
            return View();
        }


        /// <summary>
        /// Отвечаем на вопрос, а также убираем отвеченный вопрос
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Client_Response_Support(int Id, string text)
        {
            if (text != null)
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(bid_DB.Objects[Id].user.Email, "Ответ на вопрос", text);
                support_DB.Objects[Id].Active = false;
                support_DB.Object_operation.RemoveToDB(support_DB.Objects);
                return Redirect("../../Home/HomePage");
            }
            else
            {
                ViewBag.Message = "Введите ответ на вопрос";
                return View(Id);
            }
        }

        /// <summary>
        /// Обрабатываем заявку, а также обработанную заявку убираем
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Client_Response_Bid(int id, string text)
        {
            if (text != null)
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(bid_DB.Objects[id].user.Email, bid_DB.Objects[id].service, text);


                bid_DB.Objects[id].active = false;
                bid_DB.Object_operation.RemoveToDB(bid_DB.Objects);
                return Redirect("../../Home/HomePage");
            }
            else
            {
                ViewBag.Message = "Введите текст для ответа";
                return View(id);
            }
        }

        /// <summary>
        /// Рассылка всем пользователям активным
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Client_Response_Mailing(string Message)
        {
            if (Message != null)
            {
                foreach (var mailing in mailing_DB.Objects)
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
                return Redirect("../Manager/Client_Response_Mailing");
            }
           
        }
    }
}
