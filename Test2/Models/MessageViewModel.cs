using System;

namespace Test2
{
	public class MessageViewModel
	{
		public MessageViewModel ()
		{
		}

		public string Message {
			get;
			set;
		}

		public override string ToString ()
		{
			return Message;
		}
	}
}

