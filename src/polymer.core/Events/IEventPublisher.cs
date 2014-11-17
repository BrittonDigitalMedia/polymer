namespace polymer.core.Events
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent thisEvent);
    }
}