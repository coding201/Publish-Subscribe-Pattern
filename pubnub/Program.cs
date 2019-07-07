using Ninject;
using pubnub.logic;
using System;

namespace pubnub
{
    public class Program
    {
        private static IPublishLogic _publishLogic;
        static void Main(string[] args)
        {
            InitialiaseIoC();

            Console.WriteLine("Welcome! We have two channels: 1. Numbers, 2. Texts. First thing we should do is to add subscribers for each channel. Let's get started.");

            Console.WriteLine("How many subscriber do you want to add for Numbers channel?");
            string numbersLine = Console.ReadLine();

            Console.WriteLine("How many subscriber do you want to add for Text channel?");
            string textLine = Console.ReadLine();

            int numberChannelValue;
            if (int.TryParse(numbersLine, out numberChannelValue))
            {
                for (int i = 0; i < numberChannelValue; i++)
                {
                    _publishLogic.CreateNumberChannelSubscriber();
                }

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{numberChannelValue} subscriber has been added to Number channel!");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Error: Please enter a number");
                Console.ResetColor();
            }


            int textChannelValue;
            if (int.TryParse(textLine, out textChannelValue))
            {
                for (int i = 0; i < textChannelValue; i++)
                {
                    _publishLogic.CreateTextChannelSubscriber();
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{textChannelValue} subscriber has been added to Text channel!");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Error: Please enter a number");
                Console.ResetColor();
            }

            Console.WriteLine("Enter number or text to publish data. In order to quit, enter exit.");
            string line;
            while ((line = Console.ReadLine()) != "exit")
            {
                int intValue;
                if (int.TryParse(line, out intValue))
                {
                    _publishLogic.Publish(intValue);
                }
                else
                {
                    _publishLogic.Publish(line);
                }

                Console.WriteLine("Say anything else: number or text. In order to quit enter exit.");
            }

            Console.WriteLine("Thank you! bye.");
        }

        private static void InitialiaseIoC()
        {
            var kernel = new StandardKernel();
            kernel.Load(AppDomain.CurrentDomain.GetAssemblies());
            _publishLogic = kernel.Get<IPublishLogic>();
        }
    }
}

