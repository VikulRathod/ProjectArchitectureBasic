using VHaaSh.Models.Account;
using VHaaSh.Models.Notifications;
using VHaaSh.Notifications;

namespace VHaaSh.BusinessLogicLayer.BusinessLogic.Account
{
    public class NotificationsBL
    {
        private IEmailNotifications _email;

        public NotificationsBL()
        {
            _email = new EmailNotifications();
        }

        public bool SendPasswordResetEmail(EmailRequest emailRequest, ResetPasswordRequest resetPassword)
        {
            return _email.SendPasswordResetEmail(emailRequest, resetPassword);
        }
    }
}
