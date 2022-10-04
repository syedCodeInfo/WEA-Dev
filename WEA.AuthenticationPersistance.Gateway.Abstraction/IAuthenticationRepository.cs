using IN= WEA.AuthenticationPersistance.Collabration.Abstraction.IndoorRelay;
using OUT= WEA.AuthenticationPersistance.Collabration.Abstraction.OutdoorRelay;

namespace WEA.AuthenticationPersistance.Gateway.Abstraction
{
    public interface IAuthenticationRepository
    {
        public OUT.BasicUserDetails GetUserDetails(IN.LoginCredential loginCredential);
    }
}
