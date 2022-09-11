namespace VHaaSh.API.DAL
{
    public static class VHaaShDB
    {
        public static string spRegisterUser = "spRegisterUser";
        public static string spActivateRegisteredUser = "spActivateRegisteredUser";
        public static string spSaveOtpInDatabase = "usp_SaveOtpInDatabase";
        public static string spGetOtpFromDatabase = "usp_GetOtpFromDatabase";
        public static string spAuthenticateUser = "spAuthenticateUser";
        public static string spChangePasswordOnFirstLogin = "usp_ChangePasswordOnFirstLogin";
    }
}
