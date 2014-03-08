using System;
using Sloth.Core.Infrastructure;
using Sloth.Internal.Contracts;
using Sloth.Core.Infrastructure.Receiver;

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

