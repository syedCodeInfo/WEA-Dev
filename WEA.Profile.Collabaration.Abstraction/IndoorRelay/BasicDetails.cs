using System;
using System.Collections.Generic;
using System.Text;

namespace WEA.Profile.Collabaration.Abstraction.IndoorRelay
{
    public class BasicDetails
    {
        public int userId { get; set; }
        public string Line { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public DateTime InaugrationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public string status { get; set; }
    }
}
