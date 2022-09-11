using System.Net;
using System.Net.Http;
using System.Web.Http;
using VHaaSh.API.BLL.Account;
using VHaaShAPIModals.Account;

namespace VHaaSh.API.Controllers
{
    public class PasswordManageController : ApiController
    {
        private IAccountControllerBL _accountBL;

        public PasswordManageController(IAccountControllerBL accountBL)
        {
            _accountBL = accountBL;
        }

        [HttpPost]
        public HttpResponseMessage ChangePasswordOnFirstLogin([FromBody] LoginRequest login)
        {
            int result = _accountBL.ChangePasswordOnFirstLogin(login.Username, login.Password, login.Password);

            if (result == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Password changed successful");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
