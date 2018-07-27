using System;

namespace OpenCqrs.Store.EF.Entities
{
    public class EventEntity
    {
        public long Id { get; set; }
        public long AggregateId { get; set; }
        public long CommandId { get; set; }
        public int Sequence { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime TimeStamp { get; set; }
        public long? UserId { get; set; }
        public string Source { get; set; }
    }
}
