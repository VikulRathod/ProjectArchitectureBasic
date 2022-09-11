using System;
using VHaaSh.Models.Account;

namespace VHaaSh.DataAccessLayer.Interfaces.Account
{
    public interface IAuthorizationDB
    {
        ResetPasswordRequest ResetPasswordRequest(string userName);
        bool IsPasswordResetLinkValid(Guid userGuid);
        bool ChangePassword(Guid userGuid, string password);
        bool ChangePasswordUsingCurrentPassword(string userName, string password, string newPassword);
    }
}
