using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WEA.AccountCreation.Collabaration.Abstraction;
using WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay;
using WEA.CourseFilter.Collabration.Abstraction;
using WEA.CourseFilter.Collabration.Abstraction.IndoorRelay;
using WEA.FAQServices.Collabration.Abstraction;
using WEA.FAQServices.Collabration.Abstraction.IndoorRelay;
using WEA.FinanceAccount.Collabration.Abstraction;
using WEA.FinanceAccount.Collabration.Abstraction.IndoorRelay;

namespace WEA_DEV.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountCreationPersistance _accountCreationPersistance;
        private readonly ICourseFilterPersistance _courseFilterPersistance;
        private readonly IFAQPersistance _faqPersistance;
        private readonly IFinancialPersistance _financialPersistance;
        public UserController(IAccountCreationPersistance accountCreationPersistance, ICourseFilterPersistance courseFilterPersistance, IFAQPersistance faqPersistance, IFinancialPersistance financialPersistance)
        {
            _accountCreationPersistance=accountCreationPersistance;
            _courseFilterPersistance= courseFilterPersistance;
            _faqPersistance = faqPersistance;
            _financialPersistance= financialPersistance;    
        }
        public IActionResult Index()
        {
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            TempData["TotalCourse"] = _courseFilterPersistance.TotalCourse(userId);
            return View();
        }
        public IActionResult ViewMyProfile()
        {
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            var profileDetails = _accountCreationPersistance.ViewAll(userId);
            return View(profileDetails);
        }
        public IActionResult AddBasicInformation()
        {
            
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            var profileInfo = _accountCreationPersistance.ViewAll(userId);
          if(profileInfo==null)
            {
                TempData["StatusInformation"] = null;

            }
            else 
            {
                TempData["StatusInformation"] = profileInfo.Status;
            }
          
            return View("AddBasicInformation");
        }
      
        [HttpPost]
        public IActionResult AddBasicInformation(UserInfo userInfo)
        {
            DateTime currentDate= DateTime.Now;
            var dob = userInfo.DOB;
            var diffOfDate= (currentDate - dob).Days/365;
            if(diffOfDate>=18)
            {
                var userId = int.Parse(HttpContext.Session.GetString("userId"));
                userInfo.UserId = userId;
                bool response= _accountCreationPersistance.AddBasicInformation(userInfo);
                if(response)
                {
                    TempData["AlertMessage"] = "Successfully Basic Information Added";
                    return Redirect("AddBasicInformation");
                }
                else
                {
                    TempData["AlertMessage"] = "Error Occured";
                    return Redirect("AddBasicInformation");
                }
            }
            else
            {
                TempData["ageStatus"] = "Invalid Age";
                return View();
            }
          
        }
        public IActionResult AddChildInfo()
        {

            return View("AddChildInfo");
        }
        [HttpPost]
        public IActionResult AddChildInfo(ChildrenInfo child)
        {
            DateTime currentDate = DateTime.Now;
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            child.UserId = userId;
            var dob = child.DOB;
            var diffOfDate = (currentDate - dob).Days / 365;
            if (diffOfDate >= 10)
            {
                _accountCreationPersistance.AddChildren(child);
                return RedirectToAction(actionName: "Index", controllerName: "User");
            }
            else
            {
                TempData["ageStatus"] = "Invalid Age";
                return View();
            }


        }
        [HttpGet]
        public IActionResult CourseInformation()
        {
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            var courseDetails= _courseFilterPersistance.ViewAllCourseByQualification(userId);
            return View(courseDetails);
        }
        public IActionResult CourseJoin(int id)
        {
            UserCourse userCourse = new UserCourse();
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            var joinCourseDetails = _courseFilterPersistance.ViewAllJoinedCourse(userId);
            if(id>0)
            {
                userCourse.CourseId = id;
                userCourse.UserId = userId;

                var courseDetails = _courseFilterPersistance.JoinOfferedCourse(userCourse);
            }
            return View(joinCourseDetails);
        }
       

        public IActionResult MyChild()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));
            var childInformation=  _accountCreationPersistance.ViewChildren(userId);
            return View(childInformation);
        }
        [HttpGet]
        public IActionResult ViewAllRespondedFAQ()
        {
            var displayAllFAQ = _faqPersistance.ViewAllResponsedFAQ();
            return View(displayAllFAQ);
        }
        public IActionResult AddFAQ()
        {
            return View("AddFAQ");
        }
        [HttpPost]
        public IActionResult AddFAQ(FAQInfo faqService)
        {

            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            faqService.UserId = userId;
            faqService.UserType = 2;
            faqService.ResponserId = 1;
            var result = _faqPersistance.AddFAQ(faqService);
            if (result)
            {
                TempData["AlertMessage"] = "Successfully Question Added";
                return Redirect("AddFAQ");
            }
            else
            {
                TempData["AlertMessage"] = "Error Occurred";
                return View();
            }

        }
        [HttpGet]
        public IActionResult DisplayDepositAmount()
        {
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            var finaincalInformation = _financialPersistance.GetDepositdetails(userId);
            return View(finaincalInformation);
        }
        [HttpGet]
        public IActionResult DepositAmount(int id)
        {
            ChildFinancialAccount childFinancialAccount = new ChildFinancialAccount();
            childFinancialAccount.ChildId = id;
            return View(childFinancialAccount);
        }
        [HttpPost]
        public IActionResult DepositAmount(ChildFinancialAccount childFinancialAccount)
        {
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            childFinancialAccount.UserId = userId;
            _financialPersistance.createFinancialAccount(childFinancialAccount);
            return View("Index");
        }
    }
}
