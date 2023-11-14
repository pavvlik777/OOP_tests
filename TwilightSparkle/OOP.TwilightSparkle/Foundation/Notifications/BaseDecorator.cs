namespace OOP.TwilightSparkle.Foundation.Notifications
{
    /*
    var notifier = new ConsoleNotificationService();
    if (emailEnabled)
    {
        notifier = new EmailNotificationService(notifier);
    }

    if (smsEnabled)
    {
        notifier = new SmsNotificationService(notifier);
    }
    */
    public abstract class BaseDecorator : INotifier //PATTERN Decorator
    {
        private readonly INotifier _wrapee;


        public BaseDecorator(INotifier wrapee)
        {
            _wrapee = wrapee;
        }


        public virtual void SendNotification()
        {
            _wrapee.SendNotification();
        }
    }
}
