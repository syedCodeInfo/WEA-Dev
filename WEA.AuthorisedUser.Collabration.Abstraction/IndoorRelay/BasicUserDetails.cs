using System;

namespace WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay
{
    public class BasicUserDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string GuradianeName { get; set; }
        public string Qualification { get; set; }
         public string Line { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public string status { get; set; }
    }
}
