using System;
using System.Collections.Generic;
using System.Text;

namespace WEA.Persistance.Entity
{
    public class BasicInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
