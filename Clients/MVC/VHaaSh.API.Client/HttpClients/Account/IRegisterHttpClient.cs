using VHaaShAPIModals.Notifications;
using VHaaShModals.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VHaaSh.API.Client.HttpClients.Account
{
    public interface IRegisterHttpClient
    {
        HttpResponseMessage RegisterUser(UserInfo userInfo);
        HttpResponseMessage ActivateRegisteredUser(OtpRequest request);
        HttpResponseMessage Authenticate(LoginRequest login);
        HttpResponseMessage ChangePasswordOnFirstLogin(LoginRequest login);
    }
}
