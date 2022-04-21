using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Context.Data;
using MyswlEfCoreDemo.Models;
using System.Configuration;

namespace MyswlEfCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static string connectionString;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        }

        public IActionResult Index()
        {
            using (MyDbContext ctx = new MyDbContext(connectionString))
            {
                var lista = ctx.Prodotto.ToList();
                var prodotto = lista.FirstOrDefault();
                prodotto.Descrizione = "Modificato";
                ctx.SaveChanges();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
