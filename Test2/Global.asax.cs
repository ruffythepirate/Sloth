using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Test2
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private static IWindsorContainer _container;


		public static void RegisterRoutes (RouteCollection routes)
		{

			log4net.Config.DOMConfigurator.Configure(); 

			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

			routes.MapRoute (
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = "" }
			);

		}


		protected void Application_Start ()
		{
			AreaRegistration.RegisterAllAreas ();
			RegisterRoutes (RouteTable.Routes);

			BootstrapContainer ();
		}

		protected void Application_End()
		{
			if (_container != null) {
				_container.Dispose ();
			}
		}


		private static void BootstrapContainer()
		{
			_container = new WindsorContainer()
				.Install(FromAssembly.This());

			var controllerFactory = new WindsorControllerFactory(_container.Kernel);

			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
		}
	}
}
