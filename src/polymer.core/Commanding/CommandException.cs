using System;

namespace polymer.core.Commanding
{
	public class CommandException : ApplicationException
	{
		public CommandException(ICommand command, string commandName, Exception innerException)
			: base(
				string.Format(
					"an error occurred while processing a command of type {0}. See the inner exception for details",
					commandName), innerException)
		{
			this.Command = command;
		}

		public ICommand Command { get; set; }
	}
}