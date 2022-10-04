

using System.Collections.Generic;
using WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedUser.Collabration.Abstraction.OutdoorRelay;

namespace WEA.AuthorisedUser.Collabration.Abstraction
{
    public interface IAuthoriseUserPersistance
    {
        public bool SaveAuthorisedUser(BasicUserDetails basicUserDetails);
        public int TotalUser();
        public List<FinanicalDetails> DisplayAllFinancialInformation();
        public List<BasicUserDetails> DisplayAllUserInformation();
        public List<FAQList> DisplayAllFAQ();
        public bool SaveAnswer(AddAnswer answer);
        public bool ConvertingUserToAuthorised(AuthorisationStatus authorisation);
        public int TotalNGO();
        public int TotalCourse();

    }
}
