namespace polymer.core.Commanding
{
	public interface ICommandHandler<TCommand, TResult> 
		where TCommand : ICommand, ICommand<TResult>
		where TResult : ICommandResult
	{

		TResult Handle(TCommand command);
	}
}