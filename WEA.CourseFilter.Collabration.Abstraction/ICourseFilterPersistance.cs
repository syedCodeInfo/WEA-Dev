using System.Collections.Generic;
using WEA.CourseFilter.Collabration.Abstraction.IndoorRelay;
using WEA.CourseFilter.Collabration.Abstraction.OutdoorRelay;

namespace WEA.CourseFilter.Collabration.Abstraction
{
    public interface ICourseFilterPersistance
    {
        public List<CourseBreif> ViewAllCourseByQualification(int userId);
        public List<CourseInformation> ViewAllJoinedCourse(int userId);
        public bool JoinOfferedCourse(UserCourse userCourse);
        public int TotalCourse(int userId);

    }
}
