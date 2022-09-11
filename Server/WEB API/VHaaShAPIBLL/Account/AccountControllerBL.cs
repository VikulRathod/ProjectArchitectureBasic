using VHaaSh.API.DAL.Account;
using VHaaSh.Notifications.Email;
using VHaaSh.Utilities;
using VHaaShAPIModals.Account;
using VHaaShAPIModals.Notifications;

namespace VHaaSh.API.BLL.Account
{
    public class AccountControllerBL : IAccountControllerBL
    {
        IAccountControllerDB _iAccountControllerDAL;
        private ILoginHelper _loginHelper;
        private IEmailNotifications _emailNotification;

        public AccountControllerBL(IAccountControllerDB iAccountControllerDB,
            ILoginHelper loginHelper, IEmailNotifications emailNotification)
        {
            _iAccountControllerDAL = iAccountControllerDB;
            _loginHelper = loginHelper;
            _emailNotification = emailNotification;
        }

        public int RegisterUser(string firstName, string lastName, 
            string mobile, string email)
        {
            string otp = _loginHelper.GenerateRandomOtp();
            int result = _iAccountControllerDAL.RegisterUser(firstName, lastName, mobile, email, otp);

            OtpRequest request = new OtpRequest() { Mobile = mobile, Email = email, Otp = otp };
            SentOtp(request);

            return result;
        }

        void SentOtp(OtpRequest request)
        {
            OtpResponse emailresponse = _emailNotification.SendOTP(request);
            SaveOtpInDatabase(request.Mobile, request.Email, request.Otp);
        }

        public int ActivateRegisteredUser(string mobile, string password, string email, string otp)
        {
            return _iAccountControllerDAL.ActivateRegisteredUser(mobile, password, email, otp);
        }

        public void SaveOtpInDatabase(string mobile, string email, string otp)
        {
            _iAccountControllerDAL.SaveOtpInDatabase(mobile, email, otp);
        }

        public string GetOtpFromDatabase(string mobile, string email)
        {
            return _iAccountControllerDAL.GetOtpFromDatabase(mobile, email);
        }

        public User Authenticate(string username, string password)
        {
            return _iAccountControllerDAL.Authenticate(username, password);
        }

        public int ChangePasswordOnFirstLogin(string userName, string currentPassword, string newPassword)
        {
            return _iAccountControllerDAL.ChangePasswordOnFirstLogin(userName, currentPassword, newPassword);
        }
    }
}
