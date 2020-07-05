using System;

namespace Helpers.EventBus
{
    public class BusEvent
    {
        protected Action _handlers;

        public virtual void Subscribe(Action handler)
        {
            _handlers += handler;
        }

        public virtual void Desubscribe(Action handler)
        {
            _handlers -= handler;
        }

        public virtual void Publish()
        {
            _handlers?.Invoke();
        }
    }

    public class BusEvent<T>
    {
        protected Action<T> _handlers;

        public virtual void Subscribe(Action<T> handler)
        {
            _handlers += handler;
        }

        public virtual void Desubscribe(Action<T> handler)
        {
            _handlers -= handler;
        }

        public virtual void Publish(T value)
        {
            _handlers?.Invoke(value);
        }
    }
}
