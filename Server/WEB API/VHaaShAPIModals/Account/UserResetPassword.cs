using System;

namespace VHaaShAPIModals.Account
{
    public class UserResetPassword
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ResetRequestDateTime { get; set; }
    }
}
