using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using VHaaShAPIModals;
using VHaaShAPIModals.Notifications;

namespace VHaaSh.Notifications.Sms
{
    public class SMSNotifications : ISMSNotifications
    {
        private string _apiKey = GlobalConstants.SmsGatewayApiKey;
        private string _apiurl = GlobalConstants.SmsGatewayApiUrl;

        // sened TextSmsDetails object in parameter
        public OtpResponse SendOTP(OtpRequest request)
        {
            OtpResponse otpresponse = new OtpResponse();

            string apiUrl = "https://2factor.in/API/V1/";
            string apiKey = "dfa9edac-69b8-11ea-9fa5-0200cd936042";

            using (var client = new HttpClient())
            {
                string url = apiUrl + apiKey + "/ADDON_SERVICES/SEND/TSMS";

                client.BaseAddress = new Uri(url);

                var responseTask = client.PostAsync<OtpRequest>("", request, new JsonMediaTypeFormatter(), null);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OtpResponse>();
                    readTask.Wait();

                    otpresponse = readTask.Result;
                }
            }

            return otpresponse; // Text sms sent failed
        }

        public OtpResponse VerifyOTP(OtpRequest request)
        {
            OtpResponse otpresponse = new OtpResponse();

            using (var client = new HttpClient())
            {
                string url = _apiurl + _apiKey + "/SMS/VERIFY/" + request.SessionId + "/" + request.Otp;

                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OtpResponse>();
                    readTask.Wait();

                    otpresponse = readTask.Result;
                }
            }

            return otpresponse;
        }

        public OtpResponse SendLoginDetails(LoginDetails request)
        {
            OtpResponse otpresponse = new OtpResponse();

            using (var client = new HttpClient())
            {
                string url = _apiurl + _apiKey + "/ADDON_SERVICES/SEND/TSMS";

                client.BaseAddress = new Uri(url);

                var responseTask = client.PostAsync<LoginDetails>("", request, new JsonMediaTypeFormatter(), null);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OtpResponse>();
                    readTask.Wait();

                    otpresponse = readTask.Result;
                }
            }

            return otpresponse;
        }

        public OtpResponse SendOTP(TextSmsDetails request)
        {
            OtpResponse otpresponse = new OtpResponse();

            string apiUrl = "https://2factor.in/API/V1/";
            string apiKey = "dfa9edac-69b8-11ea-9fa5-0200cd936042";

            using (var client = new HttpClient())
            {
                string url = apiUrl + apiKey + "/ADDON_SERVICES/SEND/TSMS";

                client.BaseAddress = new Uri(url);

                var responseTask = client.PostAsync<TextSmsDetails>("", request, new JsonMediaTypeFormatter(), null);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OtpResponse>();
                    readTask.Wait();

                    otpresponse = readTask.Result;
                }
            }

            return otpresponse; // Text sms sent failed
        }
    }
}
