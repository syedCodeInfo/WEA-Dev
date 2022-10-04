using System;
using WEA.AuthenticationPersistance.Collabration.Abstraction;
using WEA.AuthenticationPersistance.Collabration.Abstraction.IndoorRelay;
using WEA.AuthenticationPersistance.Collabration.Abstraction.OutdoorRelay;
using WEA.AuthenticationPersistance.Gateway.Abstraction;

namespace WEA.AuthenticationPersistance.Collabration.Realization
{
    public class AuthenticationPersistance : IAuthenticationPersistance
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationPersistance(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public BasicUserDetails GetUserDetails(LoginCredential loginCredential)
        {
           return _authenticationRepository.GetUserDetails(loginCredential);
        }
    }
}
