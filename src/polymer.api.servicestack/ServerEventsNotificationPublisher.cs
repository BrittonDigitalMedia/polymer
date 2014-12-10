using polymer.core.Notifications;
using ServiceStack;

namespace polymer.api.servicestack
{
	public class ServerEventsNotificationPublisher : INotificationPublisher
	{
		private readonly IServerEvents _serverEvents;

		public ServerEventsNotificationPublisher(IServerEvents serverEvents)
		{
			_serverEvents = serverEvents;
		}

		public void Publish(INotification notification)
		{
			_serverEvents.NotifyChannel(notification.GetType().Name, notification);
		}
	}
}
