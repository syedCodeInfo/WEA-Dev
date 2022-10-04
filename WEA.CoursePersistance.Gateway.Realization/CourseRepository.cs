using System;
using System.Collections.Generic;
using System.Linq;
using WEA.CoursePersistance.Collabaration.Abstraction.IndoorRelay;
using WEA.CoursePersistance.Collabaration.Abstraction.OutdoorRelay;
using WEA.CoursePersistance.Gateway.Abstraction;
using WEA.Persistance.Entity;
using WEA.Persistance.WEADbContext;

namespace WEA.CoursePersistance.Gateway.Realization
{
    public class CourseRepository : ICourseRepository
    {
        private readonly WEAContext _weaContext;
        public CourseRepository(WEAContext weaContext)
        {
            _weaContext=weaContext;
        }
        public bool AddCourse(NgoCourse ngoCourse)
        {
            bool isCourseExist = IsCourseNameExist(ngoCourse.Name);
            bool response = false;
            if (!isCourseExist)
            {
                DateTime currentDate= DateTime.Now;
                Course course = new Course();
                course.NGOId = ngoCourse.NGOId;
                course.TrainerName = ngoCourse.TrainerName;
                course.Name = ngoCourse.Name;
                course.UserQualification = ngoCourse.UserQualification;
                course.DurationInMonth = ngoCourse.DurationInMonth;
                course.CreatedAt = currentDate;
                course.UpdatedAt = currentDate;
                course.ModifiedBy = ngoCourse.ModifiedBy;
                course.CreatedBy = ngoCourse.NGOId;
                course.status = "Requested";
                _weaContext.TblCourse.Add(course);
                var courseStatus = _weaContext.SaveChanges();
                response = courseStatus > 0 ? true : false;
            }
                     
            return response;
        }

        public int CourseCount(int ngoId)
        {
           return _weaContext.TblCourse.Where(c => c.NGOId == ngoId).Count(); 
        }

        public bool DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public List<CourseInformation> ViewAll(int ngoId)
        {
           
            var displayAllQualification=_weaContext.TblQualification.AsQueryable().ToList();    
            var displayAllCourses = _weaContext.TblCourse.AsQueryable().ToList();
            var getCourseDetails = (from ngoCourse in displayAllCourses
                                    join qualification in displayAllQualification
                                    on int.Parse(ngoCourse.UserQualification) equals qualification.Id
                                    where ngoCourse.NGOId == ngoId
                                    select new CourseInformation
                                    {
                                       Name = ngoCourse.Name,
                                       TrainerName = ngoCourse.TrainerName, 
                                       DurationInMonth= ngoCourse.DurationInMonth,
                                       UserQualification = qualification.Qualification,
                                       CreatedAt = ngoCourse.CreatedAt,
                                       CreatedBy = ngoCourse.CreatedBy,
                                       ModifiedBy=ngoCourse.ModifiedBy, 
                                       status= ngoCourse.status,
                                       UpdatedAt = ngoCourse.UpdatedAt,
                                     }).ToList();   
            return getCourseDetails;
        }
        private bool IsCourseNameExist(string courseName)
        {
            var courseDetails = _weaContext.TblCourse.AsQueryable().Where(x=>x.Name== courseName);
            int courseCount= courseDetails.Count();
            bool response = courseCount > 0 ? true:false;
            return response;

        }
    }
}
