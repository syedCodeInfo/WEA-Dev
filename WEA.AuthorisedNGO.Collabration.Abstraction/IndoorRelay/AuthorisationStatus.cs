using System;

namespace WEA.AuthorisedNGO.Collabration.Abstraction.IndoorRelay
{
    public class AuthorisationStatus
    {
        public int NGOId { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
