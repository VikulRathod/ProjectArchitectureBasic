using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHaaShModals.Account
{
    public class UserInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HighestQualification { get; set; }
        public string Occupation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
