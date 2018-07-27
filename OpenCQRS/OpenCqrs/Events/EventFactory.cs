using ReflectionMagic;

namespace OpenCqrs.Events
{
    public class EventFactory : IEventFactory
    {
        public dynamic CreateConcreteEvent(object @event)
        {
            return @event.AsDynamic();
        }
    }
}