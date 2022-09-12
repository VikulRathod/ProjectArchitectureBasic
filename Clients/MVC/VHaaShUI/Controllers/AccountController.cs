using VHaaSh.API.Client;
using VHaaShAPIModals.Notifications;
using VHaaShModals.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using VHaaSh.API.Client.Services.Account;
using VHaaSh.UI.BLL.Logs;

namespace VHaaSh.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IRegisterApiController _registerApi;
        private IApplicationLogsBL _logs;

        public AccountController(IRegisterApiController registerApi,
            IApplicationLogsBL logs)
        {
            _registerApi = registerApi;
            _logs = logs;
        }

        [HttpGet]
        public ActionResult Register()
        {
            _logs.Info("Returning register view");
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude = "Id, UserId")] UserInfo userInfo)
        {
            _logs.Info("Register Post Call Initiated");
            var response = _registerApi.RegisterUser(userInfo);

            if (response != null && response.IsSuccessStatusCode)
            {
                Session["RegisteredUserDetails"] = userInfo;
                _logs.Info("Register Post Call Success");
                return RedirectToAction("ConfirmRegister");
            }

            _logs.Error("Register Post Call Failed");
            ModelState.AddModelError("FirstName", "Error in registration");
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmRegister(string otp)
        {
            var userDetails = (UserInfo)Session["RegisteredUserDetails"];

            if (userDetails != null)
            {
                OtpRequest otpRequest = new OtpRequest()
                {
                    Email = userDetails.Email,
                    Mobile = userDetails.Mobile,
                    Otp = otp,
                    SessionId = string.Empty // this is required only to verify otp sent over sms, if we have used otp service
                };

                var response = _registerApi.ActivateRegisteredUser(otpRequest);

                if (response != null && response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "We have sent you login details on your email and mobile.";
                }
                else
                {
                    ViewBag.SendOtpAgain = true;
                }
            }

            ModelState.AddModelError("otp", "Error in otp confirmation");
            return View();
        }

        [HttpGet]
        public ActionResult ResendOtp()
        {
            // Logic to send otp details one more time
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequest login)
        {
            // use to hash password
            //string pwd = Crypto.Hash(login.Password);

            var response = _registerApi.Authenticate(login);

            if (response != null && response.IsSuccessStatusCode)
            {
                int timeout = 20;
                var ticket = new FormsAuthenticationTicket(login.Username, true, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                Session["UserName"] = login.Username;

                // call change passwor method on first time login
                //return RedirectToAction("ChangePassword");

                return RedirectToAction("Welcome", "Home");
            }
            else
            {
                ViewBag.LoginError = "Error in login";
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            if (newPassword == confirmNewPassword)
            {
                string userName = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;

                // use Crypto.Hash(newPassword)  to hash password
                LoginRequest request = new LoginRequest() { Username = userName, Password = newPassword };

                var response = _registerApi.ChangePasswordOnFirstLogin(request);

                if (response != null && response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Welcome", "Home");
                }
            }
            return View();
        }
    }
}