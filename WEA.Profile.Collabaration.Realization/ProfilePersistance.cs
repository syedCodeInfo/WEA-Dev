using System;
using System.Collections.Generic;
using WEA.Profile.Collabaration.Abstraction;
using WEA.Profile.Collabaration.Abstraction.IndoorRelay;
using WEA.Profile.Collabaration.Abstraction.OutdoorRelay;
using WEA.Profile.Gateway.Abstraction;

namespace WEA.Profile.Collabaration.Realization
{
    public class ProfilePersistance : IProfilePersistance
    {
        private readonly IProfileRepository _profileRepository;
        public ProfilePersistance(IProfileRepository profileRepository)
        {
            _profileRepository=profileRepository;   
        }
        public bool AddBasicInformation(BasicDetails basicDetails)
        {
          return _profileRepository.AddBasicInformation(basicDetails);    
        }

        public List<ProfileData> ViewAll(int id)
        {
            return _profileRepository.ViewAll(id);
        }
    }
}
