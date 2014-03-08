using System;

namespace Sloth.Core.Infrastructure.Receiver.Tests
{
	public class TestCommandHandler : 
	ICommandHandler<FirstTestCommand>,
	ICommandHandler<SecondTestCommand>
	{
		public TestCommandHandler ()
		{
		}


		public void Handle (FirstTestCommand command)
		{
			throw new NotImplementedException ();
		}

		public void Handle (SecondTestCommand command)
		{
			throw new NotImplementedException ();
		}

	}
}

