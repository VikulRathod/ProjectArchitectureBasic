using System;
using VHaaSh.BusinessLogicLayer.Interfaces.Account;
using VHaaSh.DataAccessLayer.DatabaseLogic.Account;
using VHaaSh.DataAccessLayer.Interfaces.Account;
using VHaaSh.Models.Account;

namespace VHaaSh.BusinessLogicLayer.BusinessLogic.Account
{
    public class AuthorizationBL : IAuthorizationBL
    {
        private IAuthorizationDB _dal;

        public AuthorizationBL()
        {
            _dal = new AuthorizationDB();
        }

        public ResetPasswordRequest ResetPasswordRequest(string userName)
        {
            return _dal.ResetPasswordRequest(userName);
        }

        public bool IsPasswordResetLinkValid(Guid userGuid)
        {
            return _dal.IsPasswordResetLinkValid(userGuid);
        }

        public bool ChangePassword(Guid userGuid, string password)
        {
            return _dal.ChangePassword(userGuid, password);
        }

        public bool ChangePasswordUsingCurrentPassword(string userName, string password, string newPassword)
        {
            return _dal.ChangePasswordUsingCurrentPassword(userName, password, newPassword);
        }
    }
}
