using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Model
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string  Address { get; set; }
        public int Phone { get; set; }
        public int Role { get; set; }

 
    }
}
