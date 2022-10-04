using System.Collections.Generic;
using WEA.CoursePersistance.Collabaration.Abstraction.IndoorRelay;
using WEA.CoursePersistance.Collabaration.Abstraction.OutdoorRelay;

namespace WEA.CoursePersistance.Collabaration.Abstraction
{
    public interface ICoursePersistance
    {
        public bool AddCourse(NgoCourse ngoCourse);
        public List<CourseInformation> ViewAll(int ngoId);
        public bool DeleteCourse(int courseId);
        public bool UpdateCourse(int courseId);
        public int CourseCount(int ngoId);
    }
}
