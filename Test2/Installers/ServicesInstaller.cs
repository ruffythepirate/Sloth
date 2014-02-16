using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Sloth.Core.Infrastructure;

namespace Test2
{
	public class ServicesInstaller:IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromAssemblyContaining<IMessageService>()
				.Where(  type => type.Name.EndsWith("Service"))
				.WithServiceAllInterfaces()
				.LifestyleSingleton());
		}
	}
}

