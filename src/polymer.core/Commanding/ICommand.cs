using System;

namespace polymer.core.Commanding
{
	public interface ICommand
	{
		Guid Key { get; set; }
	}

	public interface ICommand<TCommandResult> : ICommand where TCommandResult : ICommandResult
	{

	}
}