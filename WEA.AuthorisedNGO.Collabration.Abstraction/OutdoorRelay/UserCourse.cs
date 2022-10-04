using System;
using System.Collections.Generic;
using System.Text;

namespace WEA.AuthorisedNGO.Collabration.Abstraction.OutdoorRelay
{
    public class UserCourse
    {
        public string UserName { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
    }
}
