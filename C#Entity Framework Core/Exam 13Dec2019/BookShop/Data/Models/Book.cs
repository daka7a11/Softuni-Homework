using BookShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        //MinLen 3
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        //MinPrice: 0.01
        //MaxPrice: MaxDecimalValue
        public decimal Price { get; set; }

        //Min: 50
        //Max: 5000
        public int Pages { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
