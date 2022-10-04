
using System;

namespace WEA.CourseFilter.Collabration.Abstraction.IndoorRelay
{
    public class UserCourse
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
    }
}
