using System;
using System.Collections.Generic;
using System.Linq;
using WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedUser.Collabration.Abstraction.OutdoorRelay;
using WEA.AuthorisedUser.Gateway.Abstraction;
using WEA.Persistance.Entity;
using WEA.Persistance.WEADbContext;

namespace WEA.AuthorisedUsersFilter.Gateway.Realization
{
    public class AuthoriseUserRepository : IAuthoriseUserRepository
    {
        private readonly WEAContext _wEAContext;
        public AuthoriseUserRepository(WEAContext wEAContext)
        {
            _wEAContext = wEAContext;
        }
        public bool ConvertingUserToAuthorised(AuthorisationStatus authorisation)
        {

            authorisation.UpdatedAt = DateTime.Now;
            authorisation.Status = "responded";
            var updateUserInfo = _wEAContext.TblUser.Where(x => x.userId == authorisation.UserId).FirstOrDefault();
            updateUserInfo.status = authorisation.Status;
            updateUserInfo.UpdatedAt = authorisation.UpdatedAt;
            _wEAContext.TblUser.Update(updateUserInfo);
            var response = _wEAContext.SaveChanges();
            bool result = response > 0 ? true : false;
            return result;
        }
        public List<FinanicalDetails> DisplayAllFinancialInformation()
        {
            var financialInfo = _wEAContext.TblSavingAccount.ToList();
            var userDetails = _wEAContext.TblBasicInfo.ToList();
            var childDetails = _wEAContext.TblChildren.ToList();
            var finacialDetails = (from finance in financialInfo
                                   join user in userDetails
                                   on finance.UserId equals user.Id
                                   join child in childDetails
                                   on finance.ChildId equals child.Id
                                   select new FinanicalDetails
                                   {

                                       ChildName = child.Name,
                                       UserName = user.UserName,
                                       Amount = finance.Amount,
                                       CreatedAt = finance.CreatedAt,
                                       UpdatedAt = finance.UpdatedAt

                                   }).ToList();

            return finacialDetails;

        }

          public int TotalUser()
        {
            var userCount = _wEAContext.TblBasicInfo.Where(x => x.UserType == 2).Count();
            return userCount;
        }
        public int TotalNGO()
        {
            var ngoCount = _wEAContext.TblBasicInfo.Where(x => x.UserType == 3).Count();
            return ngoCount;
        }
        public int TotalCourse()
        {
            var courseCount = _wEAContext.TblCourse.Count();
            return courseCount;
        }

        public bool SaveAuthorisedUser(BasicUserDetails basicUserDetails)
        {
            BasicInfo basicInfo = new BasicInfo();
            basicInfo.UserName = basicUserDetails.UserName;
            basicInfo.UserType = 2;
            basicInfo.Email = basicUserDetails.Email;
            basicInfo.Phone = basicUserDetails.Phone;
            basicInfo.Password = basicUserDetails.Password;
            _wEAContext.TblBasicInfo.Add(basicInfo);
            _wEAContext.SaveChanges();
            var userId = _wEAContext.TblBasicInfo.Where(x => x.UserName == basicUserDetails.UserName && x.Email == basicUserDetails.Email).Select(xx => xx.Id).FirstOrDefault();

            User userInformation = new User();
            userInformation.userId = userId;
            userInformation.GuradianeName = basicUserDetails.GuradianeName;
            userInformation.status = "responded";
            userInformation.DOB = basicUserDetails.DOB;
            userInformation.Line = basicUserDetails.Line;
            userInformation.City = basicUserDetails.City;
            userInformation.PinCode = basicUserDetails.PinCode;
            userInformation.Qualification = basicUserDetails.Qualification;
            userInformation.CreatedAt = DateTime.Now;
            userInformation.ModifiedBy = 1;
            userInformation.CreatedBy = 1;
            userInformation.UpdatedAt = DateTime.Now;
            userInformation.State = basicUserDetails.State;
            _wEAContext.TblUser.Add(userInformation);
            int response = _wEAContext.SaveChanges();
            bool result = response > 0 ? true : false;
            return result;
        }

        public List<BasicUserDetails> DisplayAllUserInformation()
        {
            var basicInfo= _wEAContext.TblBasicInfo.Where(x=>x.UserType==2).ToList();
            var personalInfo = _wEAContext.TblUser.ToList();
            var qualification = _wEAContext.TblQualification.ToList();
            var fullInformation = (from basic in basicInfo
                                   join personal in personalInfo
                                   on basic.Id equals personal.userId
                                   select new BasicUserDetails
                                   {
                                       UserId= basic.Id,
                                       UserName = basic.UserName,
                                       Email = basic.Email,
                                       Phone = basic.Phone,
                                       GuradianeName= personal.GuradianeName,
                                       CreatedAt = personal.CreatedAt,
                                       City = personal.City,
                                       Line=personal.Line,
                                       status=personal.status,
                                       DOB= personal.DOB,
                                       State= personal.State,
                                       PinCode= personal.PinCode,   
                                       Qualification= (qualification.Where(x => x.Id == int.Parse(personal.Qualification)).Select(n => n.Qualification).FirstOrDefault()),

                                   }).ToList();
          return fullInformation;
        }

        public List<FAQList> DisplayAllFAQ()
        {
            var faqDetails = _wEAContext.TblFAQ.ToList();
            var userDetails= _wEAContext.TblBasicInfo.ToList();
            var faqInformation = (from faq in faqDetails
                                  join user in userDetails
                                  on faq.UserId equals user.Id
                                  select new FAQList 
                                  {
                                    Question= faq.Question,
                                    FAQId= faq.Id,
                                    Answer= faq.Answer,
                                    RequestedAt=faq.CreatedAt,
                                    UpdatedAt=faq.UpdatedAt,
                                    UserName= user.UserName
                                  }).ToList();
            return faqInformation;
        }

        public bool SaveAnswer(AddAnswer answer)
        {
            var faqDetails = _wEAContext.TblFAQ.Where(x => x.Id == answer.faqId).FirstOrDefault();
            faqDetails.Answer = answer.Answer;
            faqDetails.status = "responded";
            faqDetails.UpdatedAt= DateTime.Now;
            _wEAContext.TblFAQ.Update(faqDetails);
            var result= _wEAContext.SaveChanges();
            bool response= result>0?true:false;
            return response;


        }
    }
}
