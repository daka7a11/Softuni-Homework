using System.ComponentModel.DataAnnotations;

namespace PANDA.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
