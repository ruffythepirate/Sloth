using System;

namespace Sloth.Core.Infrastructure
{
	public interface ICommandHandler<T>
		where T : ICommand
	{

		void Handle(T command);

	}
}

