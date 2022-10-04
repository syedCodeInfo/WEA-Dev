using System;
using System.Collections.Generic;
using WEA.Persistance.WEADbContext;
using WEA.Persistance.Entity;
using WEA.Profile.Collabaration.Abstraction.IndoorRelay;
using WEA.Profile.Collabaration.Abstraction.OutdoorRelay;
using WEA.Profile.Gateway.Abstraction;
using System.Linq;

namespace WEA.Profile.Gateway.Realization
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly WEAContext _wEAContext;
        public ProfileRepository(WEAContext wEAContext)
        {
            _wEAContext= wEAContext;    
        }
        public bool AddBasicInformation(BasicDetails basicDetails)
        {
            DateTime currentDate =DateTime.Now;
            bool result = false;
            bool isExist = IsNGOExist(basicDetails);
            if(isExist)
            {
                result = false;
            }
            else
            {
                NGO ngoDetails = new NGO();
                ngoDetails.userId = basicDetails.userId;
                ngoDetails.CreatedBy = basicDetails.CreatedBy;
                ngoDetails.CreatedAt = currentDate;
                ngoDetails.UpdatedAt = currentDate;
                ngoDetails.City = basicDetails.City;
                ngoDetails.Line = basicDetails.Line;
                ngoDetails.ModifiedBy = basicDetails.ModifiedBy;
                ngoDetails.PinCode = basicDetails.PinCode;
                ngoDetails.InaugrationDate = basicDetails.InaugrationDate;
                ngoDetails.State = basicDetails.State;
                ngoDetails.status = "requested";
                _wEAContext.TblNGO.Add(ngoDetails);
                var ngoInformation = _wEAContext.SaveChanges();
                result = ngoInformation > 0 ? true : false;
            }
            
            return result;
        }

        public List<ProfileData> ViewAll(int id)
        {
            ProfileData getProfileDetails= new ProfileData();
            var profile = _wEAContext.TblNGO.Where(x =>x.userId==id).ToList();
            var basicInfo= _wEAContext.TblBasicInfo.Where(x=>x.Id==id).ToList();
            var fullDetails = (from userProfile in profile
                               join userBasicInfo in basicInfo
                               on userProfile.userId equals userBasicInfo.Id
                               select new ProfileData
                               {
                                   UserName = userBasicInfo.UserName,
                                   Phone = userBasicInfo.Phone,
                                   Password = userBasicInfo.Password,
                                   EmailAddress=userBasicInfo.Email,
                                   Status= userProfile.status,
                                   CreatedAt=userProfile.CreatedAt,
                                   UpdatedAt=userProfile.UpdatedAt,
                                   CreatedBy=userProfile.CreatedBy,
                                   ModifiedBy=userProfile.ModifiedBy,
                                   Line=userProfile.Line,
                                   PinCode=userProfile.PinCode,
                                   State = userProfile.State,
                                   InaugrationDate=userProfile.InaugrationDate,
                               }).ToList();
            return fullDetails;
        }
        private bool IsNGOExist(BasicDetails basicDetails)
        {
           var ngoDetails= _wEAContext.TblNGO.AsQueryable()
                            .Where(x=>x.userId==basicDetails.userId);
            int ngoCount= ngoDetails.Count();   
            bool result= false;
            result= ngoCount>0?true:false;
            return result;

        }
    }
}
