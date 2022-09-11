using System;
using VHaaSh.ASP.Client.Utilities;
using VHaaSh.BusinessLogicLayer.BusinessLogic.Account;

namespace VHaaSh.ASP.Client
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AuthorizationBL bl = new AuthorizationBL();
                var userGuid = Request.QueryString["uid"];

                if (!string.IsNullOrEmpty(userGuid) &&
                    !bl.IsPasswordResetLinkValid(Guid.Parse(userGuid)))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Password Reset link has expired or is invalid";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Guid uid = Guid.Parse(Request.QueryString["uid"]);
            //string newPwd = new EncryptionAlgorithm().
            //    GetEncryptedValue(txtNewPassword.Text);

            string newPwd = txtNewPassword.Text;

            AuthorizationBL bl = new AuthorizationBL();
            if (uid != null && bl.ChangePassword(uid, newPwd))
            {
                lblMessage.Text = "Password Changed Successfully!";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Password Reset link has expired or is invalid";
            }
        }
    }
}