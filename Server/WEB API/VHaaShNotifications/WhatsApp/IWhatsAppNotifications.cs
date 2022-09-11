namespace VHaaSh.Notifications.WhatsApp
{
    public interface IWhatsAppNotifications : INotifications
    {
        bool SendMessage(string toMobile, string wamessage);
    }
}
