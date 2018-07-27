using System;
using OpenCqrs.Commands;

namespace OpenCqrs.Domain
{
    public interface IDomainCommand : ICommand
    {
        long Id { get; set; }
        long AggregateRootId { get; set; }
        long? UserId { get; set; }
        string Source { get; set; }
        DateTime TimeStamp { get; set; }
    }
}
