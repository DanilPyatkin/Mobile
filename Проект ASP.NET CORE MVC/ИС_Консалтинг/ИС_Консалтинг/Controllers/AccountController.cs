using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ИС_Консалтинг.ClassOperation;
using ИС_Консалтинг.Models;
using ИС_Консалтинг.ViewModels;

namespace ИС_Консалтинг.Controllers
{
    //контроллер связанный с действием авторизации и регистрации
    public class AccountController : Controller
    {
        //считываю всех пользователей с JSON файла
        private List_Object_DB<User> user_DB;
        public AccountController()
        {
            user_DB = new List_Object_DB<User>("DB\\user.txt");
        }

        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //выход пользователя
        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("HomePage", "Home");
        }

        //Вход пользователя
        [HttpPost]
        public IActionResult Authorization(User_Authorization user)
        {
            if (ModelState.IsValid)
            {
               var page = AuthorizationUser(user).Result;
                return page;
            }
            else
            {
                return View();
            }
        }
       
        [HttpPost]
        public async Task<IActionResult> Register(User_Registeration user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(user.Email, "Консалтинговая компания Macon", "Вы успешно прошли регистрацию");
                    var page = RegistretionUser(user).Result;
                    return page;
                }
                return View();
            }
            catch
            {
                ModelState.AddModelError("Error", "Такого Email не существует");
                return View();
            }
        }

        //Вход пользователя
        private async Task<IActionResult> AuthorizationUser(User_Authorization user)
        {
            //проверка, есть ли такой пользователь
                var authorization_User = user_DB.Objects.Where(p => p.Email.ToLower() == user.Email.ToLower() && p.Password == user.Password).ToList();
                if (authorization_User.Count>=1)
                {
                    User userr = authorization_User.First();
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userr.Email),
                    new Claim(ClaimTypes.Role, userr.Role)
                };
                //аудентифицируем пользователя
                    var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect("../Home/HomePage");
            }
            else
            {
                ModelState.AddModelError("Error", "Неправильный логин или пароль");
                return View();
            }
        }

        //регистрация пользователя
        private async Task<IActionResult> RegistretionUser(User_Registeration user)
        {
            //проверка на Майл, существует или нет
            var registrazion_User = user_DB.Objects.Where(p => p.Email == user.Email).ToList();
            if (registrazion_User.Count > 0)
            {
                ModelState.AddModelError("Error", "Такой Email уже зарегистрирован");
                return View();
            }
            else
            {
                //занесения нового пользователя в базу
                User person = new User(user.Email, user.Name, user.Password);
                await Task.Run(()=>user_DB.Object_operation.SaveToDB(person));
                user_DB.Objects = user_DB.Object_operation.ReadAllFromDB();
                return Redirect("../Account/Authorization");
            }
        }
    }
}
