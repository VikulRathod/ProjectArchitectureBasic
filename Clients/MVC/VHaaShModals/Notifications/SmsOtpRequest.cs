using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHaaShAPIModals.Notifications
{
    public class OtpRequest
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string SessionId { get; set; }
        public string Otp { get; set; }
    }
}
