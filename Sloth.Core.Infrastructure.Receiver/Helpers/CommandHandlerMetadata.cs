using System;

namespace Sloth.Core.Infrastructure.Receiver
{
	public class CommandHandlerMetadata
	{
		public CommandHandlerMetadata (Type commandType, Type handlerType)
		{
			CommandType = commandType;
			HandlerType = handlerType;
		}

		/// <summary>
		/// Gets the type of the command that the handler type can handle.
		/// </summary>
		/// <value>The type of the command.</value>
		public Type CommandType {
			get;
			private set;
		}

		/// <summary>
		/// Gets the class of the handler that can handle the command.
		/// </summary>
		/// <value>The type of the handler.</value>
		public Type HandlerType {
			get;
			private set;
		}
	}
}

