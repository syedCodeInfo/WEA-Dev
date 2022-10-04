using System;
using System.Collections.Generic;
using WEA.AuthorisedNGO.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedNGO.Collabration.Abstraction.OutdoorRelay;

namespace WEA.AuthorisedNGO.Gateway.Abstraction
{
    public interface INGODetailRepository
    {
        public bool ConvertingNGOToAuthorised(AuthorisationStatus authorisation);
        public List<NGOBasicInformationFilter> DisplayNGODetails();
        public List<TrainingCourses> DisplayTrainingDetails(int id);
        public List<UserCourse> DisplayUserDetails(int id);
    }
}
