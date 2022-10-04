using System;
using System.Collections.Generic;

namespace WEA.AccountCreation.Collabaration.Abstraction.OutDoorRelay
{
    public class ProfileData
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Line { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string GuardianName { get; set; }
        public DateTime DOB { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public string Status { get; set; }
        public List<UserChildren> Children { get; set; }
     
    }
    public class UserChildren
    {
        public string Name { get; set; }
        public DateTime ChildDOB { get; set; }
        public int Grade { get; set; }
    }
   
    
}
