using System;

namespace pubnub.publish
{
    public class EventArguments<T> : EventArgs
    {
        public T Message { get; set; }
        public EventArguments(T message)
        {
            Message = message;
        }
    }
}
