namespace polymer.core.Notifications
{
    public interface INotificationPublisher
    {
        void Publish(INotification notification);
    }
}