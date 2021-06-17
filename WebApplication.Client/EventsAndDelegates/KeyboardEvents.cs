using System;
using WebApplication.Entities;

namespace WebApplication.Client.EventsAndDelegates
{
    public delegate void PressKeyEventHandler(KeyboadEventArgs args);

    public class Keyboard
    {
        public event PressKeyEventHandler PressKeyD;

        private void PressKeyDEvent(KeyboadEventArgs args)
        {
            PressKeyD?.Invoke(args);
        }

        public void Start(KeyboadEventArgs args)
        {
            while (true)
            {
                var s = Console.ReadLine();

                switch (s?.ToUpper())
                {
                    case "START":
                    {
                        PressKeyEventHandler pressKeyHEvent = (footArgs) =>
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            var client = footArgs.ReservationSystem.GetClient() as Customer;
                            if (client == null)
                            {
                                Console.WriteLine("Not a client");
                            }
                            else
                            {
                                Console.WriteLine($"Client {client.Display()} " +
                                                  $" started system");
                            }
                        };
                        pressKeyHEvent(args);
                        break;
                    }
                    case "TRIPS":
                    {
                        PressKeyEventHandler pressKeyBEvent = (footArgs) =>
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            var service = footArgs.ReservationSystem.GetReservationService();
                            service.DisplayAllExcursions();
                        };
                        pressKeyBEvent(args);
                        break;
                    }
                    case "GUIDES":
                    {
                        PressKeyEventHandler pressKeyGEvent = (footArgs) =>
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            var service = footArgs.ReservationSystem.GetReservationService();
                            service.DisplayAllGuides();
                        };
                        pressKeyGEvent(args);
                        break;
                    }
                    case "SUM_TO_PAY":
                    {
                        PressKeyEventHandler pressKeyGEvent = (footArgs) =>
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            var service = footArgs.ReservationSystem.GetReservationService();
                            service.DisplayReservationSum(footArgs.ReservationSystem.GetClient() as Customer);
                        };
                        pressKeyGEvent(args);
                        break;
                    }
                    case "EXIT":
                    {
                        PressKeyEventHandler handler = delegate(KeyboadEventArgs args)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Exit!");
                        };
                        handler(args);
                        return;
                    }
                    default:
                        Console.WriteLine("No event handler for key {0}", s);
                        break;
                }
            }

            Console.Read();
        }
    }
}