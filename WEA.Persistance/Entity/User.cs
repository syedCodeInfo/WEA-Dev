using System;

namespace WEA.Persistance.Entity
{
    public class User:Address
    {
        public int Id { get; set; }
        public DateTime DOB { get; set; }
        public string GuradianeName { get; set; }
        public string Qualification { get; set; }
       
    }
}
