using NUnit.Framework;
using System;
using System.Linq;

namespace Sloth.Core.Infrastructure.Receiver.Tests
{
	[TestFixture ()]
	public class CommandHandlerAnalyzerTest
	{
		[Test ()]
		public void TestAnalyzeAssembly ()
		{

			var foundHandlers = CommandHandlerAnalyzer.AnalyzeAssembly (typeof(FirstTestCommand).Assembly);

			var filteredHandlers = foundHandlers.Where (item => item.CommandType.Name.EndsWith ("TestCommand")).ToList();

			Assert.AreEqual (2, filteredHandlers.Count);

			Assert.AreEqual (filteredHandlers.First ().HandlerType, typeof(TestCommandHandler));
		}
	}
}

