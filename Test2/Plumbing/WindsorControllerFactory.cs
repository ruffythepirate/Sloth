using System;
using System.Web.Mvc;
using Castle.MicroKernel;
using System.Web.Routing;
using System.Web;

namespace Test2
{
	public class WindsorControllerFactory : DefaultControllerFactory
	{

		private readonly IKernel _kernel;

		public WindsorControllerFactory (IKernel kernel)
		{
			_kernel = kernel;
		}

		public override void ReleaseController (IController controller)
		{
			base.ReleaseController (controller);
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
			{
				throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
			}
			return (IController)_kernel.Resolve(controllerType);
		}
	}
}

