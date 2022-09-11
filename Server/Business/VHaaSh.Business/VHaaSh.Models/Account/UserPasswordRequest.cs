using System;

namespace VHaaSh.Models.Account
{
    public class UserPasswordRequest
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Nullable<DateTime> ResetRequestDateTime { get; set; }
    }
}
