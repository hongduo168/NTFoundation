using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenCqrs.Domain
{
    public interface IAggregateRoot
    {
        long Id { get; }
        ReadOnlyCollection<IDomainEvent> Events { get; }
        void ApplyEvents(IEnumerable<IDomainEvent> events);
    }
}
