using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEA.AuthenticationPersistance.Collabration.Abstraction;
using WEA.AuthenticationPersistance.Collabration.Abstraction.IndoorRelay;
using WEA.AuthorisedUser.Collabration.Abstraction;

namespace WEA_DEV.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationPersistance _authenticationPersistance;
        private readonly IAuthoriseUserPersistance _authoriseUserPersistance;
        public AuthenticationController(IAuthenticationPersistance authenticationPersistance, IAuthoriseUserPersistance authoriseUserPersistance)
        {
            _authenticationPersistance = authenticationPersistance;
            _authoriseUserPersistance = authoriseUserPersistance;
        }
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult Index(LoginCredential loginCredential)
        {
           var basicInformation= _authenticationPersistance.GetUserDetails(loginCredential);  
           if(basicInformation.UserName != "")
            {
                HttpContext.Session.SetString("userId", basicInformation.UserId.ToString());
                HttpContext.Session.SetString("userName", basicInformation.UserName);

                if (basicInformation.UserType == 1)
                {
                  
                    return Redirect("Admin/Index");
                }
               else if (basicInformation.UserType==2)
                {
                    
                    return Redirect("User/Index");
                }
                else if(basicInformation.UserType==3)
                {
                   
                    return Redirect("NGO/Index");

                }
               
            }
           return View("Index");
        }
    }
}
