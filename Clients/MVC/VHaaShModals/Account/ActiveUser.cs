using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHaaShModals.Account
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
