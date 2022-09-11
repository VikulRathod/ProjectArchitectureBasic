using System;
using System.Web.Security;
using VHaaSh.ASP.Client.Common;
using VHaaSh.ASP.Client.Utilities;
using VHaaSh.BusinessLogicLayer.BusinessLogic.Account;
using VHaaSh.Models.Account;

namespace VHaaSh.ASP.Client
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserName = txtUserName.Text,
                //Password = new EncryptionAlgorithm().GetEncryptedValue(txtPassword.Text)
                Password = txtPassword.Text
            };

            AuthenticateUserNew(user);
        }

        private void AuthenticateUserNew(User user)
        {
            AuthenticationBL bl = new AuthenticationBL();
            User userInfo = bl.Authenticate(user);

            int RetryAttempts = userInfo.RetryAttempts;
            if (!userInfo.IsAuthenticated &&
                !userInfo.IsAccountLocked &&
                RetryAttempts == 0)
            {
                lblMessage.Text = "Unable to login. Please type correct username and password.";
            }
            else if (userInfo.IsAccountLocked)
            {
                lblMessage.Text = "Account locked. Please contact administrator";
            }
            else if (RetryAttempts > 0)
            {
                int AttemptsLeft =
                    ConfigConstants.NumberOfLoginAttemptsAllowed - RetryAttempts;

                lblMessage.Text = "Invalid user name and/or password. " +
                    AttemptsLeft.ToString() + "attempt(s) left";
            }
            else if (userInfo.IsAuthenticated)
            {
                Session["Username"] = txtUserName.Text;
                //FormsAuthentication.RedirectFromLoginPage
                //    (txtUserName.Text, chkBoxRememberMe.Checked);
                Response.Redirect("Welcome.aspx");
            }
        }
    }
}