using System;
using System.Collections.Generic;
using WEA.AccountCreation.Collabaration.Abstraction;
using WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay;
using WEA.AccountCreation.Collabaration.Abstraction.OutDoorRelay;
using WEA.AccountCreation.Gateway.Abstraction;

using IN= WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay;

namespace WEA.AccountCreation.Collabaration.Realization
{
    public class AccountCreationPersistance : IAccountCreationPersistance
    {
        private readonly IAccountCreationRepository _accountCreationRepository;
        public AccountCreationPersistance(IAccountCreationRepository accountCreationRepository)
        {
            _accountCreationRepository = accountCreationRepository;
        }

        public bool AddBasicInformation(UserInfo userInfo)
        {
            return _accountCreationRepository.AddBasicInformation(userInfo);
        }

        public bool AddChildren(ChildrenInfo childInfo)
        {
            return _accountCreationRepository.AddChildren(childInfo);
        }

        public bool AddUser(IN.BasicUserInfo userInfo)
        {
           return _accountCreationRepository.AddUser(userInfo);
        }

        public bool ExistingUser(string email)
        {
            return _accountCreationRepository.ExistingUser(email);
        }

        public bool IsUserExist(int userId)
        {
            return _accountCreationRepository.IsUserExist(userId);
        }

        public ProfileData ViewAll(int id)
        {
            return _accountCreationRepository.ViewAll(id);
        }

        public List<ChildDetails> ViewChildren(int userId)
        {
           return _accountCreationRepository.ViewChildren(userId);  
        }
    }
}
