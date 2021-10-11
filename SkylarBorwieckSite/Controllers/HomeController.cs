using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkylarBorwieckSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SkylarBorwieckSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Sender = "";
            ViewBag.Receipient = "";
            ViewBag.Subject = "";
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(MessageModel model)
        {
            ViewBag.Sender = model.Sender;
            ViewBag.Receipient = model.Receipient;
            ViewBag.Subject = model.Subject;
            ViewBag.Message = model.Message;


            return View(model);
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Contact()
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
