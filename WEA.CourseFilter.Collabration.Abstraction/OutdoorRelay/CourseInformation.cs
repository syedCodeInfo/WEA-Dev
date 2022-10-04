using System;
using System.Collections.Generic;
using System.Text;

namespace WEA.CourseFilter.Collabration.Abstraction.OutdoorRelay
{
    public class CourseInformation
    {
        public string CourseName { get; set; }
        public string NGOName { get; set; }
        public DateTime AcceptedAt { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
    }
}
