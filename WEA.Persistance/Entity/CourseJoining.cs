using System;

namespace WEA.Persistance.Entity
{
    public class CourseJoining
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
    }
}
