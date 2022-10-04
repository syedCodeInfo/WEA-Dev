using System;
namespace WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay
{
    public class AddAnswer
    {
        public int faqId { get; set; }
        public string Answer { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
