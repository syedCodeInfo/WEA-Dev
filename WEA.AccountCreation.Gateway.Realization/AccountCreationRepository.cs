using IN= WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay;
using WEA.AccountCreation.Gateway.Abstraction;
using WEA.Persistance.WEADbContext;
using WEA.Persistance.Entity;
using System;
using WEA.Core.ENUM;
using System.Linq;
using WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay;
using System.Collections.Generic;
using WEA.AccountCreation.Collabaration.Abstraction.OutDoorRelay;

namespace WEA.AccountCreation.Gateway.Realization
{
    public class AccountCreationRepository : IAccountCreationRepository
    {
        private readonly WEAContext _wEAContext;
        public AccountCreationRepository(WEAContext wEAContext)
        {
           _wEAContext = wEAContext;
        }

        public bool AddBasicInformation(UserInfo userInfo)
        {
            bool response = false;
            bool isUserExit= IsUserExist(userInfo.UserId);
            if(isUserExit)
            {
                response = false;
            }
            else 
            {
                
                User user = new User();
                user.UpdatedAt = DateTime.Now;
                user.CreatedAt = DateTime.Now;
                user.State = userInfo.State;
                user.Line = userInfo.Line;
                user.CreatedBy = userInfo.UserId;
                user.ModifiedBy = userInfo.UserId;
                user.GuradianeName = userInfo.GuradianName;
                user.City = userInfo.City;
                user.DOB = userInfo.DOB;
                user.status = "requested";
                user.PinCode= userInfo.PinCode;
                user.Qualification= userInfo.Qualification;
                user.userId = userInfo.UserId;  
                 _wEAContext.TblUser.Add(user);
                var userDetails = _wEAContext.SaveChanges();
                response= userDetails>0?true:false;
                response = true;
            }
            return response;
        }

        public bool AddChildren(ChildrenInfo childInfo)
        {
            Children child= new Children();
            child.Grade = childInfo.Grade;
            child.Name = childInfo.Name;
            child.UserId = childInfo.UserId;
            child.DOB=childInfo.DOB;
            _wEAContext.TblChildren.Add(child);
            var result = _wEAContext.SaveChanges();
            bool response = result > 0 ? true:false;
            return response;
        }

        public bool AddUser(IN.BasicUserInfo userInfo)
        {
            bool result = false;
            BasicInfo basicInfo = new BasicInfo();
            basicInfo.Email = userInfo.Email;
            basicInfo.Phone = userInfo.Phone;
            basicInfo.UserName= userInfo.UserName;
            basicInfo.Password = userInfo.Password;
            basicInfo.UserType = userInfo.UserType;
            _wEAContext.TblBasicInfo.Add(basicInfo);
            var response=  _wEAContext.SaveChanges();
            result= response==1?true:false;
            return result;
        }

        public bool ExistingUser(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(int userId)
        {
           
            int userDetails = _wEAContext.TblUser.Where(x => x.userId ==userId).Count();
            bool result= userDetails>0?true:false;
            return result;
        }

        public ProfileData ViewAll(int id)
        {
            UserChildren userChild= new UserChildren();
            ProfileData getProfileDetails = new ProfileData();
            var profile = _wEAContext.TblUser.Where(x => x.userId == id).ToList();
            var childrens= _wEAContext.TblChildren.Where(x=>x.UserId == id).ToList();   
            var basicInfo = _wEAContext.TblBasicInfo.Where(x => x.Id == id).ToList();
            var fullDetails = (from userProfile in profile
                               join userBasicInfo in basicInfo
                               on userProfile.userId equals userBasicInfo.Id
                               join child in childrens
                               on userBasicInfo.Id equals child.UserId
                               select new ProfileData
                               {
                                   UserName = userBasicInfo.UserName,
                                   Phone = userBasicInfo.Phone,
                                   Password = userBasicInfo.Password,
                                   EmailAddress = userBasicInfo.Email,
                                   Status = userProfile.status,
                                   CreatedAt = userProfile.CreatedAt,
                                   UpdatedAt = userProfile.UpdatedAt,
                                   CreatedBy = userProfile.CreatedBy,
                                   ModifiedBy = userProfile.ModifiedBy,
                                   Line = userProfile.Line,
                                   PinCode = userProfile.PinCode,
                                   State = userProfile.State,
                                   GuardianName = userProfile.GuradianeName,
                                   DOB=userProfile.DOB,
                                   Children = (from userInfo in basicInfo
                                               join childInfo in childrens
                                               on userInfo.Id equals childInfo.UserId
                                               select new UserChildren
                                               {
                                                   ChildDOB= childInfo.DOB,
                                                   Grade= childInfo.Grade,
                                                   Name= childInfo.Name
                                               } ).ToList(),
                               
                               }).FirstOrDefault();
            return fullDetails;
        }

        public List<ChildDetails> ViewChildren(int id)
        {
            var childrens = _wEAContext.TblChildren.Where(x => x.UserId == id).ToList();
            var basicInfo = _wEAContext.TblBasicInfo.Where(x => x.Id == id).ToList();
            var child= (from userInfo in basicInfo
                       join childInfo in childrens
                       on userInfo.Id equals childInfo.UserId
                        select new ChildDetails
                        { 
                             Id=childInfo.Id,
                             DOB= childInfo.DOB,
                             Name= childInfo.Name,
                             Grade= childInfo.Grade
                        }).ToList();

            return child;
        }
    }
}
