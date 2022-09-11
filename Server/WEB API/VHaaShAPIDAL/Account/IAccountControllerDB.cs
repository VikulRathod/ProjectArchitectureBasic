using VHaaShAPIModals.Account;

namespace VHaaSh.API.DAL.Account
{
    public interface IAccountControllerDB
    {
        int RegisterUser(string firstName, string lastName, string mobile, string email, string otp);

        int ActivateRegisteredUser(string mobile, string password, string email, string otp);

        void SaveOtpInDatabase(string mobile, string email, string otp);

        string GetOtpFromDatabase(string mobile, string email);

        User Authenticate(string username, string password);

        int ChangePasswordOnFirstLogin(string userName, string currentPassword, string newPassword);
    }
}
