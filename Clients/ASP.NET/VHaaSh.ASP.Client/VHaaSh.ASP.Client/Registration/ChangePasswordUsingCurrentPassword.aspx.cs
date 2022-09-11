using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using VHaaSh.ASP.Client.Utilities;
using VHaaSh.BusinessLogicLayer.BusinessLogic.Account;

namespace VHaaSh.ASP.Client
{
    public partial class ChangePasswordUsingCurrentPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["uid"] == null && User.Identity.Name == "")
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["uid"] != null)
                {
                    if (!IsPasswordResetLinkValid())
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Password Reset link has expired or is invalid";
                    }
                    trCurrentPassword.Visible = false;
                }
                else if (User.Identity.Name != "")
                {
                    trCurrentPassword.Visible = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if ((Request.QueryString["uid"] != null && ChangeUserPassword()) ||
                (User.Identity.Name != "" && ChangeUserPasswordUsingCurrentPassword()))
            {
                lblMessage.Text = "Password Changed Successfully!";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                if (trCurrentPassword.Visible)
                {
                    lblMessage.Text = "Invalid Current Password!";
                }
                else
                {
                    lblMessage.Text = "Password Reset link has expired or is invalid";
                }
            }
        }

        private bool ExecuteSP(string SPName, List<SqlParameter> SPParameters)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(SPName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in SPParameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                con.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        private bool IsPasswordResetLinkValid()
        {
            AuthorizationBL bl = new AuthorizationBL();
            var userGuid = Request.QueryString["uid"];

            return (!string.IsNullOrEmpty(userGuid) &&
                !bl.IsPasswordResetLinkValid(Guid.Parse(userGuid)));
        }

        private bool ChangeUserPassword()
        {
            Guid uid = Guid.Parse(Request.QueryString["uid"]);
            //string newPwd = new EncryptionAlgorithm().
            //    GetEncryptedValue(txtNewPassword.Text);

            string newPwd = txtNewPassword.Text;

            AuthorizationBL bl = new AuthorizationBL();
            return (uid != null && bl.ChangePassword(uid, newPwd));
        }

        private bool ChangeUserPasswordUsingCurrentPassword()
        {
            AuthorizationBL bl = new AuthorizationBL();

            string userName = User.Identity.Name;
            //string password = FormsAuthentication.
            //    HashPasswordForStoringInConfigFile(txtCurrentPassword.Text, "SHA1");
            //string newPassword = FormsAuthentication.
            //    HashPasswordForStoringInConfigFile(txtNewPassword.Text, "SHA1");

            string password = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;

            return bl.ChangePasswordUsingCurrentPassword(userName, password, newPassword);
        }
    }
}