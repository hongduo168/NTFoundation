using System;

namespace OpenCqrs.Domain
{
    public abstract class Entity : IEntity
    {
        public long Id { get; protected set; }

        protected Entity()
        {
            Id = new IdWorker(DateTime.Now.Ticks).NextId();
        }

        protected Entity(long id)
        {
            if (id == 0)
                id = new IdWorker(DateTime.Now.Ticks).NextId(); ;

            Id = id;
        }        
    }
}
