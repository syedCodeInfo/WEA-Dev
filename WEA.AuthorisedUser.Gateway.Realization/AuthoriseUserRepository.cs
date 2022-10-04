using System;
using System.Collections.Generic;
using System.Linq;
using WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedUser.Collabration.Abstraction.OutdoorRelay;
using WEA.AuthorisedUser.Gateway.Abstraction;
using WEA.Persistance.Entity;
using WEA.Persistance.WEADbContext;

namespace WEA.AuthorisedUser.Gateway.Realization
{
    public class AuthoriseUserRepository : IAuthoriseUserRepository
    {
        private readonly WEAContext _wEAContext;
        public AuthoriseUserRepository(WEAContext wEAContext)
        {
            _wEAContext = wEAContext;
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
                                   
                                    ChildName= child.Name,
                                    UserName= user.UserName,
                                    Amount= finance.Amount,
                                    CreatedAt= finance.CreatedAt,
                                    UpdatedAt= finance.UpdatedAt

                                   }).ToList();

            return finacialDetails;

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
            var userId= _wEAContext.TblBasicInfo.Where(x=>x.UserName==basicUserDetails.UserName && x.Email== basicUserDetails.Email).Select(xx=>xx.Id).FirstOrDefault();

            User userInformation = new User();
            userInformation.userId= userId;
            userInformation.GuradianeName= basicUserDetails.GuradianeName;
            userInformation.status = "responded";
            userInformation.DOB = basicUserDetails.DOB;
            userInformation.Line = basicUserDetails.Line;
            userInformation.City = basicUserDetails.City;
            userInformation.PinCode = basicUserDetails.PinCode;
            userInformation.Qualification = basicUserDetails.Qualification;
            userInformation.CreatedAt= DateTime.Now;
            userInformation.ModifiedBy = 1;
            userInformation.CreatedBy = 1;
            userInformation.UpdatedAt = DateTime.Now;   
            userInformation.State =basicUserDetails.State;
            _wEAContext.TblUser.Add(userInformation);
            int response=_wEAContext.SaveChanges();
            bool result= response>0?true:false;
            return result;

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
    }
}
