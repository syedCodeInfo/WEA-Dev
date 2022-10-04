namespace WEA.Persistance.Entity
{
    public class Address:EntityEnumType
    {
        public int userId { get; set; }
        public string Line { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
    }
}
