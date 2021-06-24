using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using admin_cms.Models;
using Microsoft.AspNetCore.Http;

namespace admin_cms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()

        {
            ViewBag.Message = this.HttpContext.Request.Cookies["alunos"];
            return View();
        }

        public IActionResult Privacy()
        {
           this.HttpContext.Response.Cookies.Append("alunos", "alunos do torne-se um programador",new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddSeconds(10),
                HttpOnly = true,
            });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
