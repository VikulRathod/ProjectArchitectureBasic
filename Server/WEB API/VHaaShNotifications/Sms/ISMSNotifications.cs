using VHaaShAPIModals.Notifications;

namespace VHaaSh.Notifications.Sms
{
    public interface ISMSNotifications : INotifications
    {
        OtpResponse SendOTP(TextSmsDetails request);
    }
}
