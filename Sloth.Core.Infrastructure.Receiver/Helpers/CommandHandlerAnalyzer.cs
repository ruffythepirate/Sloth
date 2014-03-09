using System;
using System.Linq;
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
					if (implementedInterface.IsConstructedGenericType
					    && implementedInterface.GetGenericTypeDefinition () == typeof(ICommandHandler<>)) {

						//We get the method signature for the command handler.
						var commandTypeForHandleMethod = GetCommandTypeForInterface (implementedInterface);

						var commandHandler = new CommandHandlerMetadata (
							                     commandTypeForHandleMethod,
							                     type);

						handlers.Add (commandHandler);
					}
				}				
			}

			return handlers;

		}

		static Type GetCommandTypeForInterface (Type handlerInterface)
		{
			var handleMethod = handlerInterface.GetMethods ().FirstOrDefault ();
			if (handleMethod == null) {
				throw new InvalidOperationException ("Expected to find a handle method in the ICommandHandler interface");
			}
			var inputParameters = handleMethod.GetParameters ();
			if (inputParameters.Length != 1) {
				throw new InvalidOperationException ("Only expected one input parameter to the Handle method");
			}
			var commandTypeForHandleMethod = inputParameters [0].ParameterType;
			return commandTypeForHandleMethod;
		}
	}
}

