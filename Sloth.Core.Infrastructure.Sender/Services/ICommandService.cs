using System;

namespace Sloth.Core.Infrastructure.Sender.Services
{
	public interface ICommandService
	{
		void SendCommand(string targetQueue, ICommand command);
	}
}

