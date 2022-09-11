using System;

namespace VHaaSh.Models.Account
{
    public class ResetPasswordRequest
    {
        public string Username { get; set; }
        public Guid UserGuid { get; set; }
        public string Email { get; set; }
        public bool IsEmailSent { get; set; } // task: add this property in db
    }
}
