using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VHaaSh.API.BLL.Account;
using VHaaSh.API.BLL.Logs;
using VHaaShAPIModals.Account;

namespace APIAuthentication.Controllers
{
    public class RegisterController : ApiController
    {
        private IAccountControllerBL _accountBL;
        private IApplicationLogsBL _log;

        public RegisterController(IAccountControllerBL accountBL,
            IApplicationLogsBL log)
        {
            _accountBL = accountBL;
            _log = log;
        }

        [HttpPost]
        public HttpResponseMessage RegisterUser([FromBody] UserInfo userInfo)
        {
            try
            {
                _log.Info("RegisterUser API Started..");
                if (userInfo != null)
                {
                    int result = _accountBL.RegisterUser(userInfo.FirstName, userInfo.LastName, userInfo.Mobile, userInfo.Email);
                    _log.Info("RegisterUser API Completed..");

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                _log.Error($"RegisterUser API Error BadRequest");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "");
            }
            catch (Exception ex)
            {
                _log.Error($"RegisterUser API Error {ex.Message}");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //[HttpPut]
        //public HttpResponseMessage ActivateRegisteredUser([FromBody] OtpRequest request)
        //{
        //    try
        //    {
        //        if (request != null)
        //        {
        //            // Uncomment below line if you want to verify otp sent over sms
        //            //OtpResponse smsResponse = notification.VerifyOTP(request);
        //            OtpResponse emailResponse = _emailNotification.VerifyOTP(request);

        //            if (emailResponse.Status == "Success")
        //            {

        //                string password = new LoginHelper().GeneratePassword(8);
        //                //string password = _loginHelper.GeneratePassword(8);

        //                int result = _accountBL.ActivateRegisteredUser(request.Mobile, password, request.Email, request.Otp);

        //                // Uncomment below lines if you want to send first time login details over sms

        //                //LoginDetails req = new LoginDetails()
        //                //{
        //                //    From = "VHAASH",
        //                //    To = request.Mobile,
        //                //    TemplateName = "VHaaShLoginAccount",
        //                //    VAR1 = "User",
        //                //    VAR2 = request.Mobile,
        //                //    VAR3 = password
        //                //};

        //                //OtpResponse smsResponseLoginDetails = notification.SendLoginDetails(req);

        //                LoginDetails emailreq = new LoginDetails()
        //                {
        //                    From = "VHAASH",
        //                    To = request.Email,
        //                    TemplateName = "VHaaShLoginAccount",
        //                    VAR1 = "User",
        //                    VAR2 = request.Mobile,
        //                    VAR3 = password
        //                };

        //                OtpResponse emailResponseLoginDetails = _emailNotification.SendLoginDetails(emailreq);

        //                return Request.CreateResponse(HttpStatusCode.OK, emailResponseLoginDetails);
        //            }

        //            return Request.CreateErrorResponse(HttpStatusCode.NonAuthoritativeInformation, "OTP Not Matched");
        //        }

        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }    
        //}
    }
}
