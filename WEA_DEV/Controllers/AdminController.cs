using Microsoft.AspNetCore.Mvc;
using System;
using WEA.AuthorisedNGO.Collabration.Abstraction;
using WEA.AuthorisedNGO.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedNGO.Collabration.Abstraction.OutdoorRelay;
using WEA.AuthorisedUser.Collabration.Abstraction;
using WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay;

namespace WEA_DEV.Controllers
{
    public class AdminController : Controller
    {
        private readonly INGODetailPersistance _iNGODetailPersistance;
        private readonly IAuthoriseUserPersistance _authoriseUserPersistance;
        public AdminController(INGODetailPersistance iNGODetailPersistance, IAuthoriseUserPersistance authoriseUserPersistance)
        {
            _iNGODetailPersistance= iNGODetailPersistance;
            _authoriseUserPersistance= authoriseUserPersistance;
        }
        public IActionResult Index()
        {
            TempData["TotalUser"] = _authoriseUserPersistance.TotalUser();
           
            TempData["TotalNGO"] = _authoriseUserPersistance.TotalNGO();
           
            TempData["TotalCourse"] = _authoriseUserPersistance.TotalCourse();
          
            return View();
        }
        public IActionResult DisplayAllNGO()
        {
           var ngoDetailInformation= _iNGODetailPersistance.DisplayNGODetails();
            return View(ngoDetailInformation);
        }
        [HttpGet]
        public IActionResult AuthorisedNGO(int id)
        {
            WEA.AuthorisedNGO.Collabration.Abstraction.IndoorRelay.AuthorisationStatus authorisation = new WEA.AuthorisedNGO.Collabration.Abstraction.IndoorRelay.AuthorisationStatus();
            authorisation.NGOId = id;
            var authorisedNgo= _iNGODetailPersistance.ConvertingNGOToAuthorised(authorisation);
            return View("Index");
        }
        [HttpGet]
        public IActionResult AuthorisedUser(int id)
        {
            WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay.AuthorisationStatus authorisationUser = new WEA.AuthorisedUser.Collabration.Abstraction.IndoorRelay.AuthorisationStatus();
            authorisationUser.UserId = id;
            var authorisedUser = _authoriseUserPersistance.ConvertingUserToAuthorised(authorisationUser);
            return View("Index");
        }
        [HttpGet]
        public IActionResult DisplayAllCourse(int id)
        {
            TrainingCourses trainingCourse = new TrainingCourses();
            trainingCourse.NGOId = id;
            var courseDetails = _iNGODetailPersistance.DisplayTrainingDetails(id);
            return View(courseDetails);
        }
        public IActionResult DisplayAllCourseUser()
        {
            int id =0;
            var userDetails = _iNGODetailPersistance.DisplayUserDetails(id);
            return View(userDetails);
        }
        public IActionResult DisplayAllFinancialInformation()
        {
           var financialInformation= _authoriseUserPersistance.DisplayAllFinancialInformation();
            return View(financialInformation);
        }
        public IActionResult DisplayAllUserInformation()
        {
            var userInformation = _authoriseUserPersistance.DisplayAllUserInformation();
            return View(userInformation);
        }
        public IActionResult AddUserDetails()
        {
           
            return View("AddUserDetails");
        }
        [HttpPost]
        public IActionResult AddUserDetails(BasicUserDetails basicUserDetails)
        {
            DateTime currentDate = DateTime.Now;
            var dob = basicUserDetails.DOB;
            var diffOfDate = (currentDate - dob).Days / 365;
            if (diffOfDate >= 18)
            {
                var response = _authoriseUserPersistance.SaveAuthorisedUser(basicUserDetails);
                if (response)
                {
                    TempData["AlertMessage"] = "Successfully Basic Information Added";
                    return Redirect("AddUserDetails");
                }
                else
                {
                    TempData["AlertMessage"] = "Error Occured";
                    return Redirect("AddUserDetails");
                }
            }
            else {
                TempData["ageStatus"] = "Invalid Age";
                return View();
            }
               
           
        }
        public IActionResult ViewAllFAQ()
        {
           var faqDetails= _authoriseUserPersistance.DisplayAllFAQ();
            return View(faqDetails);
        }
        [HttpGet]
        public IActionResult SaveAnswer(int id)
        {
            AddAnswer answers = new AddAnswer();
            answers.faqId=id;
            
            return View(answers);
        }
        [HttpPost]
        public IActionResult SaveAnswer(AddAnswer answers)
        {
           
           var result=_authoriseUserPersistance.SaveAnswer(answers);
            if (result)
            {
                TempData["AlertMessage"] = "Successfully Added";
                return Redirect("SaveAnswer");
            }
            else
            {
                TempData["AlertMessage"] = "Error Occured";
                return Redirect("SaveAnswer");
            }
          
        }


    }
}
