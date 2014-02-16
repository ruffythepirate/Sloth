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

		private ILogger _logger;
		public ILogger Logger {
			get{ return _logger ?? NullLogger.Instance; }  
			set{_logger = value; }
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
			Console.WriteLine ("This is an outrage, logging not working!");
			Logger.Debug("HomeController.Index");
			ViewData ["Message"] = "Welcome to ASP.NET MVC on Mono!";
			return View ();
		}


		public void AddMessage(MessageViewModel viewModel)  {
			Logger.DebugFormat ("Add Message {0}", viewModel);
			Messages.Add (viewModel.Message);
		}
	}
}

