using System;
using System.Collections.Generic;
using System.Linq;
using WEA.CourseFilter.Collabration.Abstraction.IndoorRelay;
using WEA.CourseFilter.Collabration.Abstraction.OutdoorRelay;
using WEA.CourseFilter.Gateway.Abstraction;
using WEA.Persistance.Entity;
using WEA.Persistance.WEADbContext;

namespace WEA.CourseFilter.Gateway.Realization
{
    public class CourseFilterRepository : ICourseFilterRepository
    {
        private readonly WEAContext _wEAContext;
        public CourseFilterRepository(WEAContext wEAContext)
        {
            _wEAContext = wEAContext;
        }
        public bool JoinOfferedCourse(UserCourse userCourse)
        {
            bool response=false;
            UserFilter userFilter= new UserFilter();    
            userFilter.UserId= userCourse.UserId;
            userFilter.CourseId=userCourse.CourseId;
            bool isAlreadyRequested = isAlreadyJoinedCourse(userFilter);
            if(isAlreadyRequested)
            {
                response = false;
            }
            else
            {
                CourseJoining courseJoin= new CourseJoining();
                courseJoin.CourseId=userCourse.CourseId;
                courseJoin.UserId=userCourse.UserId;
                courseJoin.Status = "Requested";
                courseJoin.UpdatedAt=DateTime.Now;
                courseJoin.RequestedAt=DateTime.Now;
                
                _wEAContext.TblCourseJoining.Add(courseJoin);
                var result = _wEAContext.SaveChanges();
                response= result>0?true:false;
               
            }
            return response;
        }

        public int TotalCourse(int userId)
        {
           int response= _wEAContext.TblCourseJoining.Where(x=>x.UserId==userId).Count();
            return response;
        }

        public List<CourseBreif> ViewAllCourseByQualification(int userId)
        {
            var userDetails = _wEAContext.TblUser.Where(x => x.userId == userId && x.status == "responded").ToList();
            var courseDetails = _wEAContext.TblCourse.ToList();
            var ngoDetails = _wEAContext.TblBasicInfo.ToList();
            var ngoStatusList = _wEAContext.TblNGO.ToList();
            var displayCourseInformation= (from userInfo in userDetails
                                          join courseInfo in courseDetails
                                          on userInfo.Qualification equals courseInfo.UserQualification
                                          join ngoInfo in ngoDetails
                                          on courseInfo.NGOId equals ngoInfo.Id
                                           join status in ngoStatusList
                                           on ngoInfo.Id equals status.userId
                                           where status.status == "responded"
                                           select new CourseBreif
                                          {
                                            CourseId= courseInfo.Id,
                                            NGOName=ngoInfo.UserName,
                                            CourseName= courseInfo.Name,
                                            Duration= courseInfo.DurationInMonth,
                                          }).ToList();
            return displayCourseInformation;
        }

        public List<CourseInformation> ViewAllJoinedCourse(int userId)
        {
           
           var courseJoiningList= _wEAContext.TblCourseJoining.Where(x=>x.UserId==userId ).ToList();
            var courseList = _wEAContext.TblCourse.ToList();
            var ngoList=_wEAContext.TblBasicInfo.ToList();
          
            var joinedCourseDetails= (from  userInfo in courseJoiningList
                                     join courseInfo in courseList
                                     on  userInfo.CourseId equals courseInfo.Id
                                     join ngoInfo in ngoList
                                     on courseInfo.NGOId equals ngoInfo.Id
                                  
                                      select new CourseInformation
                                     {
                                         CourseName= courseInfo.Name,
                                         NGOName= ngoInfo.UserName,
                                         Duration= courseInfo.DurationInMonth,
                                         AcceptedAt= userInfo.UpdatedAt,
                                         Status= userInfo.Status,

                                     }).ToList();
            return joinedCourseDetails; 
        
        }

        private bool isAlreadyJoinedCourse(UserFilter userFilter)
        {
            int userCountOnSpecificCourse=_wEAContext.TblCourseJoining.Where(x=>x.UserId==userFilter.UserId && x.CourseId==userFilter.CourseId).Count();
            bool response= userCountOnSpecificCourse>0?true:false;  
            return response;    
        }
    }
}
