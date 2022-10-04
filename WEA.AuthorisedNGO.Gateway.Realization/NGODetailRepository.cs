
using System;
using System.Collections.Generic;
using System.Linq;
using WEA.AuthorisedNGO.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedNGO.Collabration.Abstraction.OutdoorRelay;
using WEA.AuthorisedNGO.Gateway.Abstraction;
using WEA.Persistance.Entity;
using WEA.Persistance.WEADbContext;

namespace WEA.AuthorisedNGO.Gateway.Realization
{
    public class NGODetailRepository : INGODetailRepository
    {
        private readonly WEAContext _wEAContext;
        public NGODetailRepository(WEAContext wEAContext)
        {
            _wEAContext= wEAContext;    
        }
        public bool ConvertingNGOToAuthorised(AuthorisationStatus authorisation)
        {
          
            authorisation.UpdatedAt = DateTime.Now;
            authorisation.Status = "responded";
            var updateNGOInfo= _wEAContext.TblNGO.Where(x => x.userId == authorisation.NGOId).FirstOrDefault();
            updateNGOInfo.status = authorisation.Status;
            updateNGOInfo.UpdatedAt=authorisation.UpdatedAt;
            _wEAContext.TblNGO.Update(updateNGOInfo);
           var response= _wEAContext.SaveChanges();
            bool result= response>0?true:false;
            return result;
        }

        public List<NGOBasicInformationFilter> DisplayNGODetails()
        {
            var ngoDetails = _wEAContext.TblNGO.ToList();
            var basicInformation = _wEAContext.TblBasicInfo.ToList();
            var ngoBasicInformation = (from ngoInfo in ngoDetails
                                       join basic in basicInformation
                                       on ngoInfo.userId equals basic.Id
                                       select new NGOBasicInformationFilter
                                       { 
                                       Id= ngoInfo.userId,
                                        UserName = basic.UserName,
                                        Phone=basic.Phone,
                                        City=ngoInfo.City,
                                        CreatedAt= ngoInfo.CreatedAt,
                                        UpdatedAt= ngoInfo.UpdatedAt,
                                        Email= basic.Email,
                                        InaugrationDate=ngoInfo.InaugrationDate,
                                        Line=ngoInfo.Line,
                                        PinCode=ngoInfo.PinCode,
                                        State= ngoInfo.State,
                                        status=ngoInfo.status,
                                        
                                       }).ToList();
            return ngoBasicInformation;
        }

        public List<TrainingCourses> DisplayTrainingDetails( int id)
        {
            var trainingDetails= _wEAContext.TblCourse.ToList();
            var basicInformation = _wEAContext.TblBasicInfo.ToList();
            var qualification =_wEAContext.TblQualification.ToList();   
            var trainingBasicInformation = (from courseInfo in trainingDetails
                                            join basic in basicInformation  
                                            on courseInfo.NGOId equals basic.Id
                                          
                                            select new TrainingCourses
                                            { 
                                                NGOName= basic.UserName,
                                                CourseId= courseInfo.Id,
                                                CourseName= courseInfo.Name,
                                                DurationInMonth=courseInfo.DurationInMonth,
                                                TrainerName= courseInfo.TrainerName,
                                                UserQualification=(qualification.Where(x=>x.Id== int.Parse(courseInfo.UserQualification)).Select(n=>n.Qualification).FirstOrDefault() ), 

                                            }).ToList();
            return trainingBasicInformation;    
        }

        public List<UserCourse> DisplayUserDetails(int id)
        {
           var userDetails= _wEAContext.TblUser.ToList();
            var basicInformation = _wEAContext.TblBasicInfo.ToList();
           var courseJoiningDetails =_wEAContext.TblCourseJoining.ToList();
           var courseDetails = _wEAContext.TblCourse.ToList();
            var courseInformation = (from userInfo in userDetails
                                     join basic in basicInformation
                                     on userInfo.userId equals basic.Id
                                     join joinInfo in courseJoiningDetails
                                     on userInfo.userId equals joinInfo.UserId
                                     join courseInfo in courseDetails
                                     on joinInfo.CourseId equals courseInfo.Id
                                     select new UserCourse 
                                     {
                                         CourseName=courseInfo.Name,
                                        CourseId= courseInfo.Id,
                                        UserName= basic.UserName,
                                        RequestedAt=joinInfo.RequestedAt,
                                        Status= joinInfo.Status,
                                        UpdatedAt=joinInfo.UpdatedAt,
                                     
                                     }).ToList();
            return courseInformation;
        }
    }
}
