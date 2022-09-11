using System;
using System.Net.Http;
using VHaaShAPIModals.Notifications;

namespace VHaaSh.Notifications.WhatsApp
{
    public class WhatsAppNotifications : IWhatsAppNotifications
    {
        public OtpResponse SendLoginDetails(LoginDetails request)
        {
            throw new NotImplementedException();
        }

        public OtpResponse SendOTP(OtpRequest request)
        {
            throw new NotImplementedException();
        }

        public OtpResponse VerifyOTP(OtpRequest request)
        {
            throw new NotImplementedException();
        }

        public bool SendMessage(string toMobile, string wamessage)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = $"https://betablaster.in/api/send.php?number={toMobile}&type=text&message={wamessage}&instance_id=6289E30150046&access_token=75b8df77cbe8498299869d4e1d02f216";

                    var getTask = client.GetAsync(apiUrl);
                    getTask.Wait();

                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
