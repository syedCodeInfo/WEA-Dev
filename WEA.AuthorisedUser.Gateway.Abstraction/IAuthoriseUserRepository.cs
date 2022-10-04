using System;
using System.Collections.Generic;
using WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedUser.Collabration.Abstraction.OutdoorRelay;

namespace WEA.AuthorisedUser.Gateway.Abstraction
{
    public interface IAuthoriseUserRepository
    {
        public bool SaveAuthorisedUser(BasicUserDetails basicUserDetails);
        public int TotalUser();
        public List<FinanicalDetails> DisplayAllFinancialInformation();
        public List<BasicUserDetails> DisplayAllUserInformation();
        public List<FAQList> DisplayAllFAQ();
        public bool ConvertingUserToAuthorised(AuthorisationStatus authorisation);
        public bool SaveAnswer(AddAnswer answer);
        public int TotalCourse();
        public int TotalNGO();
    }
}
