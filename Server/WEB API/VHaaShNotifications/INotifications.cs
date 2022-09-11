using VHaaShAPIModals.Notifications;

namespace VHaaSh.Notifications
{
    public interface INotifications
    {
        OtpResponse SendOTP(OtpRequest request);
        OtpResponse VerifyOTP(OtpRequest request);
        OtpResponse SendLoginDetails(LoginDetails request);
    }
}
