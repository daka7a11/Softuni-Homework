using BattleCards.Services;
using BattleCards.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return Redirect("/Cards/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            string userId = usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);
            return Redirect("/Cards/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return Redirect("/Cards/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserViewModel user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || user.Username.Length < 5 || user.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 15 characters!");
            }

            if (string.IsNullOrWhiteSpace(user.Email) || !new EmailAddressAttribute().IsValid(user.Email))
            {
                return this.Error("Invalid email!");
            }

            if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 6 || user.Password.Length > 20)
            {
                return this.Error("Password length should be between 6 and 20 characters!");
            }

            if (user.Password != user.ConfirmPassword)
            {
                return this.Error("The passwords don't match!");
            }

            if (!usersService.IsUsernameValid(user.Username))
            {
                return this.Error("Username is already taken!");
            }

            if (!usersService.IsEmailValid(user.Email))
            {
                return this.Error("Given email is used by another user!");
            }

            usersService.Create(user.Username,user.Email,user.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            this.SignOut();
            return Redirect("/");
        }
    }
}
