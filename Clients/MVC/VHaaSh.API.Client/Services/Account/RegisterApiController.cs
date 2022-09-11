using System.Net.Http;
using System.Web.Mvc;
using VHaaSh.API.Client.HttpClients.Account;
using VHaaShAPIModals.Notifications;
using VHaaShModals.Account;

namespace VHaaSh.API.Client.Services.Account
{
    public class RegisterApiController : System.Web.Http.ApiController, IRegisterApiController
    {
        private IRegisterHttpClient _registerHttpClient;
        public RegisterApiController(IRegisterHttpClient registerHttpClient)
        {
            _registerHttpClient = registerHttpClient;
        }

        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage RegisterUser(UserInfo userInfo)
        {
            var response = _registerHttpClient.RegisterUser(userInfo);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPut]
        [Route("api/register")]
        public HttpResponseMessage ActivateRegisteredUser(OtpRequest request)
        {
            var response = _registerHttpClient.ActivateRegisteredUser(request);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Authenticate(LoginRequest login)
        {
            var response = _registerHttpClient.Authenticate(login);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }

        [HttpPost]
        [Route("api/passwordmanage")]
        public HttpResponseMessage ChangePasswordOnFirstLogin(LoginRequest login)
        {
            var response = _registerHttpClient.ChangePasswordOnFirstLogin(login);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            return null;
        }
    }
}