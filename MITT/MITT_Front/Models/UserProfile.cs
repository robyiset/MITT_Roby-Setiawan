using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITT_Front.Models
{
    public class UserProfile
    {
        public User_Identity user_identity { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime bod { get; set; }
        public string email { get; set; }
    }
}
