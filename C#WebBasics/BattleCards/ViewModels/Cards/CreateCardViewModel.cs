using System.ComponentModel.DataAnnotations;

namespace BattleCards.ViewModels.Cards
{
    public class CreateCardViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Keyword { get; set; }

        public int Attack { get; set; }
        public int Health { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
