using System;

namespace polymer.core.Events
{
    public interface IEvent
    {
        string EventId { get; }
        DateTime Created { get; }
    }
}