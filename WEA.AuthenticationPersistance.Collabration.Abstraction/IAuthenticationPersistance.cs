using System;
using IN= WEA.AuthenticationPersistance.Collabration.Abstraction.IndoorRelay;
using OUT= WEA.AuthenticationPersistance.Collabration.Abstraction.OutdoorRelay;

namespace WEA.AuthenticationPersistance.Collabration.Abstraction
{
    public interface IAuthenticationPersistance
    {
        public OUT.BasicUserDetails GetUserDetails(IN.LoginCredential loginCredential);
    }
}
