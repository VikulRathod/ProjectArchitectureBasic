using System;
using System.Web.Security;
using System.Web.UI;
using VHaaSh.BusinessLogicLayer.BusinessLogic.Account;
using VHaaSh.Models.Account;

namespace VHaaSh.ASP.Client
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AuthenticationBL bl = new AuthenticationBL();
                User user = new User()
                {
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text
                };

                //string encryptedPassword =
                //    FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");

                //user.Password = encryptedPassword;

                int returnCode = bl.Register(user);
                if (returnCode == -1)
                {
                    lblMessage.Text = "Register failed. Please try with another username or email";
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
    }
}