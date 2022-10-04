namespace WEA.Persistance.Entity
{
    public class Course: EntityEnumType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrainerName { get; set; }
        public string UserQualification { get; set; }
        public int NGOId { get; set; }
        public int DurationInMonth { get; set; }
    }
}
