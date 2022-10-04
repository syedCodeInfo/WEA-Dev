
using System;
using System.Collections.Generic;
using System.Linq;
using WEA.FAQServices.Collabration.Abstraction.IndoorRelay;
using WEA.FAQServices.Collabration.Abstraction.OutdoorRelay;
using WEA.FAQServices.Gateway.Abstraction;
using WEA.Persistance.Entity;
using WEA.Persistance.WEADbContext;

namespace WEA.FAQServices.Gateway.Realization
{
    public class FAQRepository : IFAQRepository
    {
        private readonly WEAContext _weaContext;
        public FAQRepository(WEAContext weaContext)
        {
            _weaContext=weaContext; 
        }
        public bool AddFAQ(FAQInfo faqService)
        {
            DateTime currentDate= DateTime.Now;
            FAQ faq= new FAQ();
            faq.Question=faqService.Question;
            faq.ResponserId=faqService.ResponserId;
            faq.ModifiedBy=faqService.ModifiedBy;
            faq.CreatedBy= faqService.UserId;
            faq.UserId=faqService.UserId;
            faq.CreatedAt= currentDate;
           
            faq.Answer = "";
            faq.status = "requested";
            faq.UserType= faqService.UserType;  
            _weaContext.TblFAQ.Add(faq);
            var response= _weaContext.SaveChanges();
            bool result= response>0?true:false;
            return result;
        }

        public List<FAQDetails> ViewAllResponsedFAQ()
        {
            List<FAQDetails> displayAllFAQ= new List<FAQDetails>();
         
            var faqDetails = _weaContext.TblFAQ.Where(x=>x.status=="responded").ToList();
            foreach (var faq in faqDetails)
            {
                FAQDetails getSingleFAQ = new FAQDetails();
                getSingleFAQ.Answer=faq.Answer;
                getSingleFAQ.status=faq.status;
                getSingleFAQ.UserType=faq.UserType; 
                getSingleFAQ.UpdatedAt=faq.UpdatedAt;
                getSingleFAQ.ResponserId=faq.ResponserId;
                getSingleFAQ.ModifiedBy=faq.ModifiedBy;
                getSingleFAQ.UserId = faq.UserId;
                getSingleFAQ.ModifiedBy = faq.ModifiedBy;
                getSingleFAQ.Question=faq.Question;
                getSingleFAQ.CreatedBy=faq.CreatedBy;
                displayAllFAQ.Add(getSingleFAQ);    

            }
            return displayAllFAQ;
        }
    }
}
