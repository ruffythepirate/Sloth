using System;
using System.Web.Mvc;
using Castle.MicroKernel;

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
	}
}

