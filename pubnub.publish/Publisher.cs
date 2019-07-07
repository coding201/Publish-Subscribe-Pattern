using System;

namespace pubnub.publish
{
    public class Publisher<T> : IPublisher<T>
    {
        public event EventHandler<EventArguments<T>> EventPublisher = delegate { };

        public void OnEventPublisher(EventArguments<T> args)
        {
            EventPublisher(this, args);
        }

        public void PublishData(T data)
        {
            var message = (EventArguments<T>)Activator.CreateInstance(typeof(EventArguments<T>), new object[] { data });
            OnEventPublisher(message);
        }
    }
}
