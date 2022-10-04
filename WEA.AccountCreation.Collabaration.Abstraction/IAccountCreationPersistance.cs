
using System.Collections.Generic;
using WEA.AccountCreation.Collabaration.Abstraction.OutDoorRelay;
using IN= WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay;

namespace WEA.AccountCreation.Collabaration.Abstraction
{
    public interface IAccountCreationPersistance
    {
        public bool AddUser(IN.BasicUserInfo userInfo);
        public bool ExistingUser(string email);
        public bool AddBasicInformation(IN.UserInfo userInfo);
        public bool IsUserExist(int userId);
        public ProfileData ViewAll(int id);
        public bool AddChildren(IN.ChildrenInfo childInfo);
        public List<ChildDetails> ViewChildren(int userId);
    }
}
