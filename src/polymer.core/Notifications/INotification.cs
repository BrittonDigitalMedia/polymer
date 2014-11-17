using System;

namespace polymer.core.Notifications
{
    public interface INotification
    {
        DateTime Created { get; }
    }
}