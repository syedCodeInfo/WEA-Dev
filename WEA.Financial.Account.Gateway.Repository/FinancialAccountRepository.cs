using System;
using System.Collections.Generic;
using System.Linq;
using WEA.FinanceAccount.Collabration.Abstraction.IndoorRelay;
using WEA.FinanceAccount.Collabration.Abstraction.OutdoorRelay;
using WEA.FinanceAccount.Gateway.Abstraction;
using WEA.Persistance.Entity;
using WEA.Persistance.WEADbContext;

namespace WEA.Financial.Account.Gateway.Repository
{
    public class FinancialAccountRepository : IFinancialRepository
    {
        private readonly WEAContext _wEAContext;
        public FinancialAccountRepository(WEAContext wEAContext)
        {
            _wEAContext = wEAContext;
        }
        public bool createFinancialAccount(ChildFinancialAccount childFinancialAccount)
        {
            bool response = false;
            SavingAccount account = new SavingAccount();
            account.UserId = childFinancialAccount.UserId;
            account.ChildId = childFinancialAccount.ChildId;
            account.Amount = childFinancialAccount.Amount;
            account.status = "deposited";
            account.CreatedAt = DateTime.Now;
            account.UpdatedAt = DateTime.Now;
            account.CreatedBy = childFinancialAccount.UserId;
            account.ModifiedBy = childFinancialAccount.UserId;
            bool isFinanicalAccountExit = IsExistAccount(childFinancialAccount.ChildId);
            if (isFinanicalAccountExit)
            {
                UpdateAccount(account);
                response = true;

            }
            else
            {
                SaveAccount(account);
                response = true;
            }

            return response;
        }

        public List<FinancialChildInfo> GetDepositdetails(int userId)
        {
            var childInformation = _wEAContext.TblChildren.Where(x => x.UserId == userId).ToList();
            var savingInformation = _wEAContext.TblSavingAccount.Where(x => x.UserId == userId).ToList();
            var finaicalDetails = (from childrens in childInformation
                                   join account in savingInformation
                                   on childrens.Id equals account.ChildId
                                   select new FinancialChildInfo
                                   {
                                       ChildName = childrens.Name,
                                       Amount = account.Amount,
                                       UpdatedAt = account.UpdatedAt,
                                   }).ToList();
            return finaicalDetails;
        }
        public bool IsExistAccount(int childId)
        {
            int childAccountCount = _wEAContext.TblSavingAccount.Where(x => x.ChildId == childId).Count();
            bool isAccountExit = childAccountCount > 0 ? true : false;
            return isAccountExit;
        }
        public bool SaveAccount(SavingAccount account)
        {
            _wEAContext.TblSavingAccount.Add(account);
            var result = _wEAContext.SaveChanges();
            bool response = result > 0 ? true : false;
            return response;
        }
        public bool UpdateAccount(SavingAccount account)
        {
            var exisitingAccountDetails = _wEAContext.TblSavingAccount.Where(_x => _x.ChildId == account.ChildId).FirstOrDefault();
            var totalAmount = exisitingAccountDetails.Amount + account.Amount;
            exisitingAccountDetails.Amount = totalAmount;
            _wEAContext.TblSavingAccount.Update(exisitingAccountDetails);
            var result = _wEAContext.SaveChanges();
            bool response = result > 0 ? true : false;
            return response;
        }
    }
}
