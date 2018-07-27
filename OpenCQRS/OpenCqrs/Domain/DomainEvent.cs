using System;

namespace OpenCqrs.Domain
{
    public abstract class DomainEvent : IDomainEvent
    {
        public long Id { get; set; } = new IdWorker(DateTime.Now.Ticks).NextId();
        public long AggregateRootId { get; set; }
        public long CommandId { get; set; }
        public int Version { get; set; }
        public long? UserId { get; set; }
        public string Source { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
