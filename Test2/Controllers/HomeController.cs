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
			get{ return _logger; }  
			set{ _logger = value; }
		}

		public HomeControllerService ControllerService {
			get;
			set;
		}

		public List<string> Messages {
			get;
			set;
		}

		public HomeController ()
		{
			Messages = new List<string> ();
		}

		public ActionResult Index ()
		{
			Logger.Debug ("HomeController.Index");
			ViewData ["Message"] = "Welcome to ASP.NET MVC on Mono!";
			return View ();
		}

		public void AddMessage (MessageViewModel viewModel)
		{
			try {
				Logger.DebugFormat ("Add Message {0}", viewModel);

				ControllerService.AddMessage (viewModel);
				Messages.Add (viewModel.Message);
			} catch (Exception ex) {
				Logger.ErrorFormat (ex, "Exception when adding message {0}", viewModel);
				throw;
			}

		}
	}
}

