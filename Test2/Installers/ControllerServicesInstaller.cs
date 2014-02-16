using System;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.MicroKernel.Registration;

namespace Test2
{
	public class ControllerServicesInstaller :IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly()
				.Where(  type => type.Name.EndsWith("ControllerService"))
				.LifestyleSingleton());
		}
	}
}

