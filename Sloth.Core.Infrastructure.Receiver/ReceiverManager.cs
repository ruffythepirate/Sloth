using System;
using System.Reflection;
using Castle.Core.Logging;
using System.Collections.Generic;

namespace Sloth.Core.Infrastructure.Receiver
{
	public class ReceiverManager
	{
		private ILogger _logger;

		private Dictionary<string, IMessageAdapter> _registeredCommandHandlers;

		public ReceiverManager(){
			_registeredCommandHandlers = new Dictionary<string, IMessageAdapter> ();		
		
		
		}

		public ILogger Logger {
			get{ 
				return _logger ?? NullLogger.Instance;
			}
			set{
				_logger = value;
			}
		}

		public void RegisterCommandHandlers(Assembly targetAssembly) {

			Logger.DebugFormat ("Registering command handlers in Assembly '{0}'", targetAssembly.GetName ());

			var allTypes = targetAssembly.GetExportedTypes ();

			foreach (var type in allTypes) {
				var implementedInterfaces = type.GetInterfaces ();
				foreach (var implementedInterface in implementedInterfaces) {
					//If the method implements a generic ICommandHandler.
					if (implementedInterface.GetGenericTypeDefinition () == typeof(ICommandHandler<>)) {
						RegisterCommandHandler (type, implementedInterface);
					}
				}				
			}

		}

		void RegisterCommandHandler (Type type, Type implementedInterface)
		{
			var genericTypes = implementedInterface.GetGenericArguments ();
			if (genericTypes.Length != 1) {
				throw new InvalidOperationException (string.Format ("Only expected 1 generic type parameter for type interface type '{0}', but found {1}", implementedInterface, genericTypes.Length));
			}
			var commandType = genericTypes [0];
			if (_registeredCommandHandlers.ContainsKey (commandType.FullName)) {
				throw new InvalidOperationException (string.Format ("A handler has already been registered for the command type '{0}'!", commandType.FullName));
			}

			//object handler = Activator.CreateInstance(typeof(JsonAdapter<);

			//		implementedInterface.GetMethods()[0]. handler.
			//_registeredCommandHandlers.Add (commandType.FullName, );
		}
	}

	public class DaCommand : ICommand{
	}
}

