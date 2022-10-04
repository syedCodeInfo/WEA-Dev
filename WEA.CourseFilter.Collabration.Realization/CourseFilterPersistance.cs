
using System;
using System.Collections.Generic;
using WEA.CourseFilter.Collabration.Abstraction;
using WEA.CourseFilter.Collabration.Abstraction.IndoorRelay;
using WEA.CourseFilter.Collabration.Abstraction.OutdoorRelay;
using WEA.CourseFilter.Gateway.Abstraction;

namespace WEA.CourseFilter.Collabration.Realization
{
    public class CourseFilterPersistance : ICourseFilterPersistance
    {
        private readonly ICourseFilterRepository _courseFilterRepository;
        public CourseFilterPersistance(ICourseFilterRepository courseFilterRepository)
        {
            _courseFilterRepository= courseFilterRepository;
        }
        public bool JoinOfferedCourse(UserCourse userCourse)
        {
            return _courseFilterRepository.JoinOfferedCourse(userCourse);
        }

        public int TotalCourse(int userId)
        {
            return _courseFilterRepository.TotalCourse(userId);
        }

        public List<CourseBreif> ViewAllCourseByQualification(int userId)
        {
           return _courseFilterRepository.ViewAllCourseByQualification(userId);
        }

        public List<CourseInformation> ViewAllJoinedCourse(int userId)
        {
            return _courseFilterRepository.ViewAllJoinedCourse(userId);
        }
    }
}
