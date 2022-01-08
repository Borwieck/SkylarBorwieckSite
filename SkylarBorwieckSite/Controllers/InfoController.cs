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
    public class InfoController : Controller
    {
        private readonly ILogger<InfoController> _logger;

        public InfoController(ILogger<InfoController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }
        public IActionResult People()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Quiz()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Quiz(QuizModel model)
        {
            if (QuizModel.CheckAnswer(model.SelectedAnswer,"correct"))
            {
                QuizModel.Check = "Correct";
                return View();
            }
            else
            {
                QuizModel.Check = "Incorrect";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
