using System.Net.Http;
using VHaaShAPIModals.Notifications;
using VHaaShModals.Account;

namespace VHaaSh.API.Client.Services.Account
{
    public interface IRegisterApiController
    {
        HttpResponseMessage RegisterUser(UserInfo userInfo);
        HttpResponseMessage ActivateRegisteredUser(OtpRequest request);
        HttpResponseMessage Authenticate(LoginRequest login);
        HttpResponseMessage ChangePasswordOnFirstLogin(LoginRequest login);
    }
}
