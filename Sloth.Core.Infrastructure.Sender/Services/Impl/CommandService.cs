using System;
using Castle.Core.Logging;
using RabbitMQ.Client;
using System.Text;

namespace Sloth.Core.Infrastructure.Sender.Services.Impl
{
	public class CommandService : ICommandService
	{

		public ILogger Logger {
			get;
			set;
		}
			
		public void SendCommand (string targetQueue, ICommand command)
		{
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(targetQueue, false, false, false, null);

				}
			}
		}

	}
}

