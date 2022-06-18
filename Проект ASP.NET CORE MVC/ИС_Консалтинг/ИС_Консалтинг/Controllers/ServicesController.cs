using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ИС_Консалтинг.Controllers
{
    //контроллер для просмотра информации о услугах 
    public class ServicesController : Controller
    {

        public IActionResult Analitics()
        {
            return View();
        }

        public  IActionResult Training()
        {
            return View();
        }

        public IActionResult Planning()
        {
            return View();
        }

        public IActionResult Strategy()
        {
            return View();
        }
    }
}
