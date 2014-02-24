using System;

namespace Sloth.Core.Infrastructure.Sender.Services
{
	public interface IMessageService
	{
		void SendMessage(string targetQueue, string message);
	
	}
}

