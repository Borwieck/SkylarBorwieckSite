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
        private MessageContext context { get; set; }

        public HomeController(MessageContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<MessageModel> message = MessageDB.Get();
           
            
            ViewBag.chatHistory = context.Message.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(MessageModel model)
        {

            model.MsgTime = DateTime.Now.ToString();
            if(ModelState.IsValid)
            {
                //MessageDB.AddMessage(model);
                //MessageDB.Save();

                context.Message.Add(model);
                
                context.SaveChanges();
            }

            //List<MessageModel> message = MessageDB.Get();

            //ViewBag.chatHistory = message;
            ViewBag.chatHistory = context.Message.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(MessageModel model)
        {
            MessageModel delMessage = context.Message.Find(model.MessageId);
            context.Message.Remove(delMessage);
            context.SaveChanges();

            ViewBag.chatHistory = context.Message.ToList();
            return View("Contact",new MessageModel());
        }
        public IActionResult History()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            //List<MessageModel> message = MessageDB.Get();


            ViewBag.chatHistory = context.Message.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Contact(MessageModel model)
        {

            model.MsgTime = DateTime.Now.ToString();
            if (ModelState.IsValid)
            {
                //MessageDB.AddMessage(model);
                //MessageDB.Save();

                context.Message.Add(model);

                context.SaveChanges();
            }

            //List<MessageModel> message = MessageDB.Get();

            //ViewBag.chatHistory = message;
            ViewBag.chatHistory = context.Message.ToList();
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
