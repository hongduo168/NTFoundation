using System;

namespace OpenCqrs.Domain
{
    public abstract class DomainCommand : IDomainCommand
    {
        public long Id { get; set; } = new IdWorker(DateTime.Now.Ticks).NextId();
        public long AggregateRootId { get; set; }
        public long? UserId { get; set; }
        public string Source { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
