using System;

namespace WEA.FinanceAccount.Collabration.Abstraction.IndoorRelay
{
    public class ChildFinancialAccount
    {
        public int UserId { get; set; }
        public int ChildId { get; set; }
        public double Amount { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
