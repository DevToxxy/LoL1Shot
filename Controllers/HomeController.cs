using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Controllers
{
    public class HomeController : Controller
    {

        const string  = "_Name";
        public IActionResult Index()
        {
            HttpContext.Session.SetString(, "Jarvik");
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);

            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }
    }
}
