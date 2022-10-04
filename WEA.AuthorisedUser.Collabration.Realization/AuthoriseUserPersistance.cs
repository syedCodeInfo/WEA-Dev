using System;
using System.Collections.Generic;
using WEA.AuthorisedUser.Collabration.Abstraction;
using WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedUser.Collabration.Abstraction.OutdoorRelay;
using WEA.AuthorisedUser.Gateway.Abstraction;

namespace WEA.AuthorisedUser.Collabration.Realization
{
    public class AuthoriseUserPersistance : IAuthoriseUserPersistance
    {
        private readonly IAuthoriseUserRepository _authoriseUserRepository;
        public AuthoriseUserPersistance(IAuthoriseUserRepository authoriseUserRepository)
        {
            _authoriseUserRepository=authoriseUserRepository;
        }

        public bool ConvertingUserToAuthorised(AuthorisationStatus authorisation)
        {
            return _authoriseUserRepository.ConvertingUserToAuthorised(authorisation);
        }

        public List<FAQList> DisplayAllFAQ()
        {
            return _authoriseUserRepository.DisplayAllFAQ();    
        }

        public List<FinanicalDetails> DisplayAllFinancialInformation()
        {
            return _authoriseUserRepository.DisplayAllFinancialInformation();
        }

        public List<BasicUserDetails> DisplayAllUserInformation()
        {
            return _authoriseUserRepository.DisplayAllUserInformation();
        }

        public bool SaveAnswer(AddAnswer answer)
        {
            return _authoriseUserRepository.SaveAnswer(answer);
        }

        public bool SaveAuthorisedUser(BasicUserDetails basicUserDetails)
        {
            return _authoriseUserRepository.SaveAuthorisedUser(basicUserDetails);
        }

        public int TotalCourse()
        {
            return _authoriseUserRepository.TotalCourse();
        }

        public int TotalNGO()
        {
            return _authoriseUserRepository.TotalNGO();
        }

        public int TotalUser()
        {
            return _authoriseUserRepository.TotalUser();
        }
    }
}
