using System;

namespace OpenCqrs.Store.EF.Entities
{
    public class CommandEntity
    {
        public long Id { get; set; }
        public long AggregateId { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime TimeStamp { get; set; }
        public long? UserId { get; set; }
        public string Source { get; set; }
    }
}
