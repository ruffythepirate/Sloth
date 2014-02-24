using System;
using Sloth.Core.Infrastructure.Receiver;
using Sloth.Worker.MessageHandlers;

namespace Sloth.Worker
{
	public class SlothWorker
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Starting SlothWorker...");

			ReceiverManager receiverManager = new ReceiverManager ();

			receiverManager.RegisterCommandHandlers (typeof(EnvironmentCommandHandler).Assembly);

		}
	}
}
