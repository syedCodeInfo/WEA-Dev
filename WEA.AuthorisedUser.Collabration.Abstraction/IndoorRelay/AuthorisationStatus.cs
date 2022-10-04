using System;
using System.Collections.Generic;
using System.Text;

namespace WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay
{
    public class AuthorisationStatus
    {
        public int UserId { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
