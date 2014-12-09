using polymer.core.Events;
using ServiceStack;

namespace polymer.api.servicestack
{
	public class ServerEventsNotificationPublisher : IEventPublisher
	{
		private readonly IServerEvents _serverEvents;

		public ServerEventsNotificationPublisher(IServerEvents serverEvents)
		{
			_serverEvents = serverEvents;
		}

		public void Publish<TEvent>(TEvent thisEvent)
		{
			_serverEvents.NotifyChannel(typeof(TEvent).Name, thisEvent);
		}
	}
}
