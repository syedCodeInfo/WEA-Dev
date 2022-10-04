using System;
using System.Collections.Generic;
using WEA.Core;
using ENUM= WEA.Core.ENUM;

namespace WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay
{
    public class UserInfo
    {
        public DateTime DOB { get; set; }
        public string GuradianName { get; set; }
        public string Qualification { get; set; }
        public int UserId { get; set; }
        public string Line { get; set; }
        public string Contact { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
    }
  
}
