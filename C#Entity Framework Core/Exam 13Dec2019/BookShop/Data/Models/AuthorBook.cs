using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Data.Models
{
    public class AuthorBook
    {
        [ForeignKey(nameof(Models.Author))]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey(nameof(Models.Book))]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
