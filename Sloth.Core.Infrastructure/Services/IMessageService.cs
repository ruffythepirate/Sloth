using System;

namespace Sloth.Core.Infrastructure
{
	public interface IMessageService
	{
		void SendMessage(string targetQueue, string message);
	}
}

