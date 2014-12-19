using polymer.core.Logging;
using polymer.core.Security;
using System;

namespace polymer.core.Commanding.Logging
{
	public class CommandHandlerLoggingDecorator : ICommandHandler
	{
		private readonly ICommandHandler _commandHandler;
		private readonly IUserSession _userSession;
		private readonly ILogger _logger;

		public CommandHandlerLoggingDecorator(ICommandHandler commandHandler,
			IUserSession userSession, ILogger logger)
		{
			_commandHandler = commandHandler;
			_userSession = userSession;
			_logger = logger;
		}

		// <exception cref="CommandException">thrown when an error occurs while processing a command</exception>
		public ICommandResult Handle(ICommand command)
		{
			var commandLogRecord = new CommandLogRecord(LogLevel.Internal, LogType.System, string.Format("executed command {0}", command.GetType().Name), "CODE", _userSession);
			try
			{
				var result = _commandHandler.Handle(command);
				_logger.LogInfo(commandLogRecord);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(commandLogRecord);
				throw new CommandException(command, "TestCommand", ex);
			}
		}
	}
}
