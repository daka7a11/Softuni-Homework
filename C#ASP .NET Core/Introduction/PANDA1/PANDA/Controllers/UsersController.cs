using Microsoft.AspNetCore.Mvc;
using PANDA.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PANDA.Controllers
{
    public class UsersController : Controller
    {
        public UsersController() 
        { 
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            List<string> errorMessages = new List<string>();

            if (model.Password != model.ConfirmPassword)
            {
                errorMessages.Add("The passwords should be equals!");
            }

            if (!ModelState.IsValid)
            {

                var errors = ModelState.Select(x => x.Value.Errors)
                .Where(x => x.Count > 0)
                .ToList();

                foreach (var error in errors)
                {
                    string errorMsg = error[0]?.ErrorMessage.ToString();
                    errorMessages.Add(errorMsg);
                }

                return this.View("Error", errorMessages);
            }



            return this.Redirect("/Users/Login");
        }
    }
}
