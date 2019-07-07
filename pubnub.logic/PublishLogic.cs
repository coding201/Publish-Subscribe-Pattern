using pubnub.publish;
using pubnub.subscribe;
using System;
using System.Collections.Generic;

namespace pubnub.logic
{
    public class PublishLogic : IPublishLogic
    {
        private readonly IPublisher<int> _intPublisher; 
        private readonly IPublisher<string> _stringPublisher;
        private bool stringHandlerAdded;
        public IList<int> RecievedInt { get;  set; }

        public PublishLogic(IPublisher<int> intPublisher, IPublisher<string> stringPublisher)
        {
            _intPublisher = intPublisher; //create publisher of type integer
            _stringPublisher = stringPublisher; //create publisher of type integer 
            RecievedInt = new List<int>();
        }

        public void CreateNumberChannelSubscriber()
        {
            Subscriber<int> intSubscriber = new Subscriber<int>(_intPublisher);
            intSubscriber.Publisher.EventPublisher += NumberChannel; //event method to listen publish data
        }

        public void CreateTextChannelSubscriber()
        {
            Subscriber<string> intSubscriber = new Subscriber<string>(_stringPublisher);
            intSubscriber.Publisher.EventPublisher += TextChannel; //event method to listen publish data
        }

        public void Publish(int value)
        {
            _intPublisher.PublishData(value); // publisher publish message
        }

        public void Publish(string value)
        {
            _stringPublisher.PublishData(value); // publisher publish message
        }

        public void NumberChannel(object sender, EventArguments<int> e)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Hey. I got the number: {e.Message}.");
            Console.ResetColor();
            RecievedInt.Add(e.Message);
        }

        public void TextChannel(object sender, EventArguments<string> e)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;       
            Console.WriteLine("Hey I got the text: " + e.Message);
            Console.ResetColor();
        }
    }
}
