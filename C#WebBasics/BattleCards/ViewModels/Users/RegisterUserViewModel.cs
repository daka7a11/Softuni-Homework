using System.ComponentModel.DataAnnotations;

namespace BattleCards.ViewModels.Users
{
    public class RegisterUserViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string ConfirmPassword { get; set; }
    }
}
