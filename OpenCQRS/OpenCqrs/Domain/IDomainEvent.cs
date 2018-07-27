using System;
using OpenCqrs.Events;

namespace OpenCqrs.Domain
{
    public interface IDomainEvent : IEvent
    {
        long Id { get; set; }
        long AggregateRootId { get; set; }
        long CommandId { get; set; }
        int Version { get; set; }
        long? UserId { get; set; }
        string Source { get; set; }
        DateTime TimeStamp { get; set; }
    }
}
