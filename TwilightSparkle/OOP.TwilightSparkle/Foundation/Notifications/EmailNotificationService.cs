using System;

namespace OOP.TwilightSparkle.Foundation.Notifications
{
    public sealed class EmailNotificationService : BaseDecorator
    {
        public EmailNotificationService(INotifier wrapee)
            : base(wrapee)
        {

        }


        public override void SendNotification()
        {
            base.SendNotification();
            Console.WriteLine("Sent via Email."); //Using some service
        }
    }
}
