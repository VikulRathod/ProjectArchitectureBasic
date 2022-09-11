namespace VHaaShAPIModals.Notifications
{
    public class OtpRequest
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string SessionId { get; set; }
        public string Otp { get; set; }
    }

    public class TextSmsDetails : OtpRequest
    {
        public string From { get; set; }
        public string To { get; set; }

        public string TemplateName { get; set; }
        public string VAR1 { get; set; }
        public string VAR2 { get; set; }
        public string VAR3 { get; set; }
    }
}
