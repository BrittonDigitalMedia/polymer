using System;

namespace polymer.core.Commanding
{
	public class CommandException : ApplicationException
	{
		public CommandException(ICommand command, string commandName, Guid key, Exception innerException)
			: base(
				string.Format(
					"an error occurred while processing a command of type {0} with the key {1}. See the inner exception for details",
					commandName, key), innerException)
		{
			this.Command = command;
		}

		public ICommand Command { get; set; }
	}
}