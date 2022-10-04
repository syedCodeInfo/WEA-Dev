using System;
using System.Collections.Generic;
using WEA.Profile.Collabaration.Abstraction.IndoorRelay;
using WEA.Profile.Collabaration.Abstraction.OutdoorRelay;

namespace WEA.Profile.Collabaration.Abstraction
{
    public interface IProfilePersistance
    {
        public bool AddBasicInformation(BasicDetails basicDetails);
        public List<ProfileData> ViewAll(int id);

    }
}
