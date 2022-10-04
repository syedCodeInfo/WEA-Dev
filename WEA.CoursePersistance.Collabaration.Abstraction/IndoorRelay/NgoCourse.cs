using System;

namespace WEA.CoursePersistance.Collabaration.Abstraction.IndoorRelay
{
    public class NgoCourse
    {
        public string Name { get; set; }
        public string TrainerName { get; set; }
        public string UserQualification { get; set; }
        public int NGOId { get; set; }
        public int DurationInMonth { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public string status { get; set; }
    }
}
