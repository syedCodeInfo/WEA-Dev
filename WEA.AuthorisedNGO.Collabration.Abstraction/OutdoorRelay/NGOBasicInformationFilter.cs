using System;

namespace WEA.AuthorisedNGO.Collabration.Abstraction.OutdoorRelay
{
    public class NGOBasicInformationFilter
    {
        public int Id { get; set; }
        public DateTime InaugrationDate { get; set; }
        public string Line { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       public string status { get; set; }
    }
}
