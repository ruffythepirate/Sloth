using System;

namespace Sloth.Core.Infrastructure.Receiver
{
	public interface ICommandHandler<T>
		where T : ICommand
	{

		void Handle(T command);

	}
}

