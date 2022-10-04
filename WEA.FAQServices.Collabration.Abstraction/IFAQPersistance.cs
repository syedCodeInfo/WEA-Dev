using System;
using System.Collections.Generic;
using WEA.FAQServices.Collabration.Abstraction.IndoorRelay;
using WEA.FAQServices.Collabration.Abstraction.OutdoorRelay;

namespace WEA.FAQServices.Collabration.Abstraction
{
    public interface IFAQPersistance
    {
        public bool AddFAQ(FAQInfo faqService);
        public List<FAQDetails> ViewAllResponsedFAQ();
    }
}
