using System;
using System.Collections.Generic;
using WEA.AuthorisedNGO.Collabration.Abstraction;
using WEA.AuthorisedNGO.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedNGO.Collabration.Abstraction.OutdoorRelay;
using WEA.AuthorisedNGO.Gateway.Abstraction;

namespace WEA.AuthorisedNGO.Collabration.Realization
{
    public class NGODetailPersistance : INGODetailPersistance
    {
        private readonly INGODetailRepository _iNGODetailRepository;
        public NGODetailPersistance(INGODetailRepository iNGODetailRepository)
        {
            _iNGODetailRepository= iNGODetailRepository;    
        }
        public bool ConvertingNGOToAuthorised(AuthorisationStatus authorisation)
        {
           return _iNGODetailRepository.ConvertingNGOToAuthorised(authorisation);
        }

        public List<NGOBasicInformationFilter> DisplayNGODetails()
        {
            return _iNGODetailRepository.DisplayNGODetails();
        }

        public List<TrainingCourses> DisplayTrainingDetails(int id)
        {
            return _iNGODetailRepository.DisplayTrainingDetails(id);
        }

        public List<UserCourse> DisplayUserDetails(int id)
        {
           return _iNGODetailRepository.DisplayUserDetails(id);
        }
    }
}
