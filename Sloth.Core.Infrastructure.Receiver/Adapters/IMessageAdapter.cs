using System;

namespace Sloth.Core.Infrastructure.Receiver
{
	public interface IMessageAdapter
	{
		void HandleMessage (string serializedMessage);
	}
}

