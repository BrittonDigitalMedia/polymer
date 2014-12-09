namespace polymer.core.Events
{
	public interface IEventHandler<in TEvent> where TEvent : IEvent
	{
		void Handle(TEvent thisEvent);
	}
}
