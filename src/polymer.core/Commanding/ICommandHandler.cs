namespace polymer.core.Commanding
{
	public interface ICommandHandler<TCommand, TResult> : ICommandHandler
		where TCommand : ICommand, ICommand<TResult>
		where TResult : ICommandResult
	{

		TResult Handle(TCommand command);
	}

	public interface ICommandHandler
	{
		ICommandResult Handle(ICommand command);
	}
}