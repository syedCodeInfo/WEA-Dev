
using System.Collections.Generic;
using WEA.FAQServices.Collabration.Abstraction;
using WEA.FAQServices.Collabration.Abstraction.IndoorRelay;
using WEA.FAQServices.Collabration.Abstraction.OutdoorRelay;
using WEA.FAQServices.Gateway.Abstraction;

namespace WEA.FAQServices.Collabration.Realization
{
    public class FAQPersistance : IFAQPersistance
    {
        private readonly IFAQRepository _fAQRepository;
        public FAQPersistance(IFAQRepository fAQRepository)
        {
            _fAQRepository=fAQRepository;
        }
        public bool AddFAQ(FAQInfo faqService)
        {
           return _fAQRepository.AddFAQ(faqService);
        }

        public List<FAQDetails> ViewAllResponsedFAQ()
        {
            return _fAQRepository.ViewAllResponsedFAQ();
        }
    }
}
