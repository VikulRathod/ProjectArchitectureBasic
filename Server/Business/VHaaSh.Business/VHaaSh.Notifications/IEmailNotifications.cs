using VHaaSh.Models.Account;
using VHaaSh.Models.Notifications;

namespace VHaaSh.Notifications
{
    public interface IEmailNotifications
    {
        bool SendPasswordResetEmail(EmailRequest emailRequest,ResetPasswordRequest resetPassword);
    }
}
