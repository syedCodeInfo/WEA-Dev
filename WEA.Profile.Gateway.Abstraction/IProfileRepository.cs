using System;
using System.Collections.Generic;
using WEA.Profile.Collabaration.Abstraction.IndoorRelay;
using WEA.Profile.Collabaration.Abstraction.OutdoorRelay;

namespace WEA.Profile.Gateway.Abstraction
{
    public interface IProfileRepository
    {
        public bool AddBasicInformation(BasicDetails basicDetails);
        public List<ProfileData> ViewAll(int id);
    }
}
