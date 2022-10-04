using System;
using System.Collections.Generic;
using System.Text;

namespace WEA.CoursePersistance.Collabaration.Abstraction.OutdoorRelay
{
    public class CourseInformation
    {
        public string Name { get; set; }
        public string TrainerName { get; set; }
        public string UserQualification { get; set; }
        public int DurationInMonth { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public string status { get; set; }
    }
}
