using System;

namespace VHaaSh.Models.Account
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> RegisteredDateTime { get; set; }
        public Nullable<DateTime> ModifiedDateTime { get; set; }
        public Nullable<DateTime> DeletedDateTime { get; set; }
        public bool IsActive { get; set; }
        public int RetryAttempts { get; set; }
        public bool IsAccountLocked { get; set; }
        public Nullable<DateTime> LockedDateTime { get; set; }
    }

    public partial class User
    {
        public bool IsAuthenticated { get; set; }
    }
}
