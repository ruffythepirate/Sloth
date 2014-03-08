using System;
using System.Reflection;
using System.Collections.Generic;

namespace Sloth.Core.Infrastructure.Receiver
{
	public static class CommandHandlerAnalyzer
	{
		public static IEnumerable<CommandHandlerMetadata> AnalyzeAssembly (Assembly assemblyToAnalyze)
		{


			var handlers = new List<CommandHandlerMetadata> ();

			var allTypes = assemblyToAnalyze.GetExportedTypes ();

			foreach (var type in allTypes) {
				var implementedInterfaces = type.GetInterfaces ();
				foreach (var implementedInterface in implementedInterfaces) {
					//If the method implements a generic ICommandHandler.
					if ( implementedInterface.ContainsGenericParameters
						&& implementedInterface.GetGenericTypeDefinition () == typeof(ICommandHandler<>)) {
						var commandHandler = new CommandHandlerMetadata (
							implementedInterface.GetGenericArguments() [0],
							                     implementedInterface);
						handlers.Add (commandHandler);
					}
				}				
			}

			return handlers;

		}
	}
}

