using System;

namespace OOP.TwilightSparkle.Foundation.Notifications
{
    public sealed class ConsoleNotificationService : INotifier
    {
        public void SendNotification()
        {
            Console.WriteLine("Notification via console.");
        }
    }
}
