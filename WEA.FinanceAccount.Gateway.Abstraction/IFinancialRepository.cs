using System;
using System.Collections.Generic;
using WEA.FinanceAccount.Collabration.Abstraction.IndoorRelay;
using WEA.FinanceAccount.Collabration.Abstraction.OutdoorRelay;

namespace WEA.FinanceAccount.Gateway.Abstraction
{
    public interface IFinancialRepository
    {
        public bool createFinancialAccount(ChildFinancialAccount childFinancialAccount);
        public List<FinancialChildInfo> GetDepositdetails(int userId);
    }
}
