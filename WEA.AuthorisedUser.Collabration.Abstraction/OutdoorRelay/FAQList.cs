using System;
using System.Collections.Generic;
using System.Text;

namespace WEA.AuthorisedUser.Collabration.Abstraction.OutdoorRelay
{
    public class FAQList
    {
        public int FAQId { get; set; }
        public string UserName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
