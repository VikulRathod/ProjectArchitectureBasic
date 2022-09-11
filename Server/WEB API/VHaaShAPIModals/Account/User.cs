using System;

namespace VHaaShAPIModals.Account
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RetryAttempts { get; set; }
        public int AccountLocked { get; set; }
        public DateTime LockedDateTime { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int IsAuthenticated { get; set; }
    }
}
