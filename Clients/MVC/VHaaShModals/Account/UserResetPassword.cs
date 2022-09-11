using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHaaShModals.Account
{
    public class UserResetPassword
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ResetRequestDateTime { get; set; }
    }
}
