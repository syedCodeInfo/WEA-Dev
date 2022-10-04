using System;
using System.Collections.Generic;
using System.Linq;
using WEA.AuthenticationPersistance.Collabration.Abstraction.IndoorRelay;
using WEA.AuthenticationPersistance.Collabration.Abstraction.OutdoorRelay;
using WEA.AuthenticationPersistance.Gateway.Abstraction;
using WEA.Persistance.WEADbContext;
using WEA.Persistance.Entity;

namespace WEA.AuthenticationPersistance.Gateway.Realization
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly WEAContext _wEAContext;
        public AuthenticationRepository(WEAContext wEAContext)
        {
            _wEAContext = wEAContext;
        }
        public BasicUserDetails GetUserDetails(LoginCredential loginCredential)
        {
           BasicUserDetails userDetails = new BasicUserDetails();
            var query = _wEAContext.TblBasicInfo.AsQueryable();
            var authorisedUser=query.Where(u=>u.Email==loginCredential.Email && u.Password==loginCredential.Password).ToList();
            userDetails = DisplayUser(authorisedUser);
            return userDetails;
        }
        private BasicUserDetails DisplayUser(List<BasicInfo> basicInfo)
        {
            BasicUserDetails userDetails = new BasicUserDetails();
            if (basicInfo.Count > 0)
            {
                foreach(var info in basicInfo)
                {
                    userDetails.UserName = info.UserName;
                    userDetails.UserType = info.UserType;
                    userDetails.UserId = info.Id;
                }
            }
            else
            {
                userDetails.UserName = "";
                userDetails.UserType = 0;
            }
            return userDetails;
        }
    }
}
