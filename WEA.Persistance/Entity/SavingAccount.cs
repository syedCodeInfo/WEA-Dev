namespace WEA.Persistance.Entity
{
    public class SavingAccount: EntityEnumType
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChildId { get; set; }
        public double Amount { get; set; }
    }
}
