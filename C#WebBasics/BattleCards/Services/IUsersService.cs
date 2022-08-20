using BattleCards.Models;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        public void Create(string username, string email, string password);

        public string GetUserId(string username, string password);

        public bool IsUsernameValid(string username);

        public bool IsEmailValid(string email);
    }
}
