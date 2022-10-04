namespace WEA.Persistance.Entity
{
    public class FAQ:EntityEnumType
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int UserType { get; set; }
        public int ResponserId { get; set; }
    }
}
