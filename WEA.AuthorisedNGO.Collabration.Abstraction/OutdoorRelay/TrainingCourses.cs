using System;
using System.Collections.Generic;
using System.Text;

namespace WEA.AuthorisedNGO.Collabration.Abstraction.OutdoorRelay
{
    public class TrainingCourses
    {
        public string NGOName { get; set; }
        public int NGOId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string TrainerName { get; set; }
        public string UserQualification { get; set; }
        public int DurationInMonth { get; set; }
    }
}
