using System;
using RabbitMQ.Client;
using Castle.Core.Logging;
using System.Text;

namespace Sloth.Core.Infrastructure
{
	public class MessageService : IMessageService
	{
		public ILogger Logger {
			get;
			set;
		}
			
		public void SendMessage (string targetQueue, string message)
		{
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(targetQueue, false, false, false, null);

					var body = Encoding.UTF8.GetBytes(message);

					channel.BasicPublish("", targetQueue, null, body);
				
					Logger.DebugFormat ("Sent message '{0}' to queue '{1}'", message, targetQueue);
				}
			}
		}
	}
}

