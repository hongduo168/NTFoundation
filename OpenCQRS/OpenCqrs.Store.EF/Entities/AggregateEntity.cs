using System;

namespace OpenCqrs.Store.EF.Entities
{
    public class AggregateEntity
    {
        public long Id { get; set; }
        public string Type { get; set; }
    }
}
