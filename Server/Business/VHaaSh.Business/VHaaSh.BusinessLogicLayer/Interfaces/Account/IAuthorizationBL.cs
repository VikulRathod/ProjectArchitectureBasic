using System;
using VHaaSh.Models.Account;

namespace VHaaSh.BusinessLogicLayer.Interfaces.Account
{
    public interface IAuthorizationBL
    {
        ResetPasswordRequest ResetPasswordRequest(string userName);
        bool ChangePassword(Guid userGuid, string password);
        bool ChangePasswordUsingCurrentPassword(string userName, string password, string newPassword);
    }
}
