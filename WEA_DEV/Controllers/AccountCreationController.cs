using Microsoft.AspNetCore.Mvc;
using System;
using WEA.AccountCreation.Collabaration.Abstraction;
using WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay;
using IN= WEA.AccountCreation.Collabaration.Abstraction.InDoorRelay;

namespace WEA_DEV.Controllers
{
    public class AccountCreationController : Controller
    {
        private readonly IAccountCreationPersistance _accountCreationPersistance;
        public AccountCreationController(IAccountCreationPersistance accountCreationPersistance)
        {
                _accountCreationPersistance = accountCreationPersistance;
        }
     
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public IActionResult Register(IN.BasicUserInfo userInfo)
        {
            var basicInformation = _accountCreationPersistance.AddUser(userInfo);
            if(basicInformation)
            {
                TempData["AlertMessage"] = "Successfully Account Created";
                return Redirect("~/Authentication/Index");
            }
            else
            {
                TempData["AlertMessage"] = "Error Occurred";
                return View();
            }
        
          
        }
      
       
    }
}
