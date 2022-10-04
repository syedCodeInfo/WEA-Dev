using System;

namespace WEA.FAQServices.Collabration.Abstraction.OutdoorRelay
{
    public class FAQDetails
    {
        public int UserId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int UserType { get; set; }
        public int ResponserId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public string status { get; set; }
    }
}
