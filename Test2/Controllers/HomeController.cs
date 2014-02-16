using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Castle.Core.Logging;

namespace Test2.Controllers
{
	public class HomeController : Controller
	{

		public ILogger Logger {
			get;
			set;
		}

		public List<string> Messages {
			get;
			set;
		}

		public HomeController(){
			Messages = new List<string> ();
		}

		public ActionResult Index ()
		{
			ViewData ["Message"] = "Welcome to ASP.NET MVC on Mono!";
			return View ();
		}


		public void AddMessage(MessageViewModel viewModel)  {
			Messages.Add (viewModel.Message);
		}
	}
}

