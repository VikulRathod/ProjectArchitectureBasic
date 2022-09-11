using System;
using System.Text;
using VHaaSh.ASP.Client.Common;
using VHaaSh.BusinessLogicLayer.BusinessLogic.Account;
using VHaaSh.Models.Account;
using VHaaSh.Models.Notifications;

namespace VHaaSh.ASP.Client
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            AuthorizationBL bl = new AuthorizationBL();

            ResetPasswordRequest resetPassword =
                bl.ResetPasswordRequest(txtUserName.Text);

            if (resetPassword != null && resetPassword.UserGuid != null)
            {
                SendPasswordResetEmail(resetPassword);
                lblMessage.Text = "An email with instructions to reset your password is sent to your registered email";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Username not found!";
            }
        }

        private bool SendPasswordResetEmail(ResetPasswordRequest resetPassword)
        {
            bool isEmailSent = false;

            try
            {
                StringBuilder sbEmailBody = new StringBuilder();
                sbEmailBody.Append("Dear " + resetPassword.Username + ",<br/><br/>");
                sbEmailBody.Append("Please click on the following link to reset your password");
                sbEmailBody.Append("<br/><h2>Create new password <h2>");
                sbEmailBody.Append("http://localhost:58663/Registration/ChangePassword.aspx?uid=" + resetPassword.UserGuid);
                sbEmailBody.Append("<br/><h2>Reset password using current password: <h2>");
                sbEmailBody.Append("http://localhost:58663/Registration/ChangePasswordUsingCurrentPassword.aspx?uid=" + resetPassword.UserGuid);
                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("<b>VHAASH TECHNOLOGIES PVT LTD</b>");
                
                EmailRequest emailRequest = new EmailRequest()
                {
                    FromEmail = ConfigConstants.FromEmail,
                    FromEmailPassword = ConfigConstants.FromEmailPassword,
                    EmailServer = ConfigConstants.EmailServer,
                    EmailServerPort = ConfigConstants.EmailServerPort,
                    EnableSsl = ConfigConstants.EnableSsl,
                    EmailSubject = "Reset Your Password",
                    EmailBody = sbEmailBody.ToString(),
                    IsBodyHtml = true
                };

                NotificationsBL bl = new NotificationsBL();
                isEmailSent = bl.SendPasswordResetEmail(emailRequest, resetPassword);
            }
            catch (Exception ex)
            {

            }

            return isEmailSent;
        }
    }
}