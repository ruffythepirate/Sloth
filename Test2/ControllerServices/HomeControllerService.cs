using System;
using Castle.Core.Logging;
using Sloth.Core.Infrastructure;

namespace Test2
{
	public class HomeControllerService
	{

		public ILogger Logger {
			get;
			set;
		}

		public IMessageService MessageService {
			get;
			set;
		}

		public HomeControllerService ()
		{
		}

		public void AddMessage(MessageViewModel message){
			MessageService.SendMessage ("Sloth", message.Message);
		}

	}
}

