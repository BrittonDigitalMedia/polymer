namespace polymer.core.Commanding
{
	public interface ICommandHandlerFactory
	{
		TCommandHandler GetHandler<TCommandHandler>();
		ICommandHandler<TCommand, TCommandResult> GetHandlerFor<TCommand, TCommandResult>()
			where TCommand : ICommand<TCommandResult>
			where TCommandResult : ICommandResult;
	}
}