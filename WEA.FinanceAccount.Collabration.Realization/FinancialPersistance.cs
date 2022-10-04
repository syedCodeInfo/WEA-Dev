using System.Collections.Generic;
using WEA.FinanceAccount.Collabration.Abstraction;
using WEA.FinanceAccount.Collabration.Abstraction.IndoorRelay;
using WEA.FinanceAccount.Collabration.Abstraction.OutdoorRelay;
using WEA.FinanceAccount.Gateway.Abstraction;

namespace WEA.FinanceAccount.Collabration.Realization
{
    public class FinancialPersistance : IFinancialPersistance
    {
        private readonly IFinancialRepository _financialRepository;
        public FinancialPersistance(IFinancialRepository financialRepository)
        {
            _financialRepository = financialRepository;
        }
        public bool createFinancialAccount(ChildFinancialAccount childFinancialAccount)
        {
            return _financialRepository.createFinancialAccount(childFinancialAccount);
        }

        public List<FinancialChildInfo> GetDepositdetails(int userId)
        {
            return _financialRepository.GetDepositdetails(userId);
        }
    }
}
