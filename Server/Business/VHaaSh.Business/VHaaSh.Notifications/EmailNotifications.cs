using System;
using System.Net.Mail;
using VHaaSh.Models.Account;
using VHaaSh.Models.Notifications;

namespace VHaaSh.Notifications
{
    public class EmailNotifications : IEmailNotifications
    {
        public bool SendPasswordResetEmail(EmailRequest emailRequest, ResetPasswordRequest resetPassword)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(emailRequest.FromEmail, resetPassword.Email);
                
                mailMessage.IsBodyHtml = emailRequest.IsBodyHtml;
                mailMessage.Body = emailRequest.EmailBody.ToString();
                mailMessage.Subject = emailRequest.EmailSubject;
                SmtpClient smtpClient = new SmtpClient(emailRequest.EmailServer, emailRequest.EmailServerPort);

                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = emailRequest.FromEmail,
                    Password = emailRequest.FromEmailPassword
                };

                smtpClient.EnableSsl = emailRequest.EnableSsl;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
