namespace VHaaSh.Models.Notifications
{
    public class EmailRequest
    {
        public string FromEmail { get; set; }
        public string FromEmailPassword { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailServer { get; set; }
        public int EmailServerPort { get; set; }
        public bool EnableSsl { get; set; }
        public bool IsBodyHtml { get; set; }
        //public Dictionary<string, string> EmailLinks { get; set; } // description & link url
    }
}
