using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WEA.CoursePersistance.Collabaration.Abstraction;
using WEA.CoursePersistance.Collabaration.Abstraction.IndoorRelay;
using WEA.FAQServices.Collabration.Abstraction;
using WEA.FAQServices.Collabration.Abstraction.IndoorRelay;
using WEA.Profile.Collabaration.Abstraction;
using WEA.Profile.Collabaration.Abstraction.IndoorRelay;
using WEA.Profile.Collabaration.Abstraction.OutdoorRelay;

namespace WEA_DEV.Controllers
{
    public class NGOController : Controller
    {
        private readonly IProfilePersistance _profilePersistance;
        private readonly ICoursePersistance _coursePersistance;
        private readonly IFAQPersistance _faqPersistance;
        public NGOController(IProfilePersistance profilePersistance, ICoursePersistance coursePersistance, IFAQPersistance faqPersistance)
        {
            _profilePersistance = profilePersistance;
            _coursePersistance = coursePersistance;
            _faqPersistance=faqPersistance;
        }
        public IActionResult Index()
        {
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            TempData["CourseCount"] = _coursePersistance.CourseCount(userId).ToString();
            return View();
        }
        public IActionResult ViewMyProfile()
        {
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            var profileInfo = _profilePersistance.ViewAll(userId);
            return View(profileInfo);
        }
        public IActionResult AddProfile()
        {
            string status = "";
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            List<ProfileData> profileInfo=  _profilePersistance.ViewAll(userId);
            foreach(var profile in profileInfo)
            {
                status = profile.Status;
            }
            TempData["StatusInformation"]= status;  
           return View("AddProfile");
        }
        [HttpPost]
        public IActionResult AddProfile(BasicDetails basicDetails)
        {
            
            var userId= int.Parse(HttpContext.Session.GetString("userId"));
        
            basicDetails.CreatedBy = userId;
            basicDetails.userId = userId;
            var result= _profilePersistance.AddBasicInformation(basicDetails);
           

            if (result)
            {
                TempData["AlertMessage"] = "Successfully Basic Information Added";
                return Redirect("AddProfile");
            }
            else
            {
                TempData["AlertMessage"] = "Error Occurred";
                return View();
            }
          
           
        }
        public IActionResult AddCourse()
        {
            return View("AddCourse");
        }
        [HttpPost]
        public IActionResult AddCourse(NgoCourse ngoCourse)
        {

            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            ngoCourse.NGOId = userId;
            var result= _coursePersistance.AddCourse(ngoCourse);
            if (result)
            {
                TempData["AlertMessage"] = "Successfully Course Added";
                return Redirect("AddCourse");
            }
            else
            {
                TempData["AlertMessage"] = "Error Occurred";
                return View();
            }
          
           
        }
        [HttpGet]
        public IActionResult ViewAllCourse()
        {
            var userId = int.Parse(HttpContext.Session.GetString("userId"));
            var displayAllCourse= _coursePersistance.ViewAll(userId);
            return View(displayAllCourse);
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
            faqService.UserType = 3;
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
    }
}
