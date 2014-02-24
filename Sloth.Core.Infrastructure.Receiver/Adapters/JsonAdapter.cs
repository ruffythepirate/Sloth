using System;
using Newtonsoft.Json;

namespace Sloth.Core.Infrastructure.Receiver
{
	public class JsonAdapter<T> : IMessageAdapter
	{
		Action<T> _messageHandler;
		public JsonAdapter (Action<T> messageHandler)
		{
			_messageHandler = messageHandler;
		}

		public void HandleMessage (string serializedMessage)
		{
			var deserializedCommand = JsonConvert.DeserializeObject<T> (serializedMessage);
			_messageHandler.Invoke (deserializedCommand);
		}

	}
}

