using System.Configuration;

namespace VHaaSh.DataAccessLayer
{
    public static class DBConstants
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["VHaaShAuthenticationDB"].ConnectionString;
            }
        }

        public static string spRegister = "usp_RegisterUser";
        public static string spAuthenticateUser = "usp_AuthenticateUser";
        public static string spResetPassword = "usp_ResetPassword";
        public static string spIsPasswordResetLinkValid = "usp_IsPasswordResetLinkValid";
        public static string spChangePassword = "usp_ChangePassword";
        public static string spChangePasswordUsingCurrentPassword = "usp_ChangePasswordUsingCurrentPassword";
    }
}
