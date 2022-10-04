
using System;

namespace WEA.AuthorisedUser.Collabration.Abstraction.OutdoorRelay
{
    public class FinanicalDetails
    {
        public string UserName { get; set; }
        public string ChildName { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
