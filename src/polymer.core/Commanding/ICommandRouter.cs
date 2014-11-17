namespace polymer.core.Commanding
{
    public interface ICommandRouter
    {
        void Route<TCommand>(TCommand command);
    }
}