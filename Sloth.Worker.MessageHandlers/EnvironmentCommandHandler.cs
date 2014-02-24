using System;
using Sloth.Core.Infrastructure;
using Sloth.Internal.Contracts;

namespace Sloth.Worker.MessageHandlers
{
	public class EnvironmentCommandHandler : ICommandHandler<CreateEnvironmentCommand>
	{

		public void Handle (CreateEnvironmentCommand command)
		{
			throw new NotImplementedException ();
		}
			
	}
}

