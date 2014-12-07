
namespace polymer.core.Commanding
{
	public interface ICommand
	{

	}

	public interface ICommand<TCommandResult> : ICommand where TCommandResult : ICommandResult
	{

	}
}