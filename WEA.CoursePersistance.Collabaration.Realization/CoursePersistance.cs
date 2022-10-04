using System;
using System.Collections.Generic;
using WEA.CoursePersistance.Collabaration.Abstraction;
using WEA.CoursePersistance.Collabaration.Abstraction.IndoorRelay;
using WEA.CoursePersistance.Collabaration.Abstraction.OutdoorRelay;
using WEA.CoursePersistance.Gateway.Abstraction;

namespace WEA.CoursePersistance.Collabaration.Realization
{
    public class CoursePersistance : ICoursePersistance
    {
        private readonly ICourseRepository _courseRepository;
        public CoursePersistance(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public bool AddCourse(NgoCourse ngoCourse)
        {
           return _courseRepository.AddCourse(ngoCourse);
        }

        public int CourseCount(int ngoId)
        {
          return  _courseRepository.CourseCount(ngoId);
        }

        public bool DeleteCourse(int courseId)
        {
            return _courseRepository.DeleteCourse(courseId);
        }

        public bool UpdateCourse(int courseId)
        {
            return _courseRepository.UpdateCourse(courseId);
        }

        public List<CourseInformation> ViewAll(int ngoId)
        {
            return _courseRepository.ViewAll(ngoId);
        }
    }
}
