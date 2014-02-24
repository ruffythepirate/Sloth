using System;
using Sloth.Core.Infrastructure;

namespace Sloth.Internal.Contracts
{
	public class CreateEnvironmentCommand : ICommand
	{	
		public string Name {
			get;
			set;
		}
	}
}

