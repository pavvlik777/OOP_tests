using System;

namespace OOP.TwilightSparkle.Foundation.Notifications
{
    public sealed class SmsNotificationService : BaseDecorator
    {
        public SmsNotificationService(INotifier wrapee)
            : base(wrapee)
        {

        }


        public override void SendNotification()
        {
            base.SendNotification();
            Console.WriteLine("Sent via SMS."); //Using some service
        }
    }
}
