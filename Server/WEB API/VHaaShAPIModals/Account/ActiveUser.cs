using System;

namespace VHaaShAPIModals.Account
{
    public class ActiveUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoginDateTime { get; set; }
        public DateTime LogoutDateTime { get; set; }
        public bool IsActiveSession { get; set; }
    }
}
