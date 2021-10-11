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
	public class MessageController : Controller
	{
		 

		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Sender = "test1";
			ViewBag.Receipient = "test2";
			return View();
		}

		[HttpPost]
		public IActionResult Index(MessageModel model)
		{
			ViewBag.Sender = model.Sender;
			ViewBag.Receipient = model.Receipient;


			return View(model);
		}
	}
}
