﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        //MinLen 3
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        //MinLen 3
        public string LastName { get; set; }

        [Required]
        //Validate email
        public string Email { get; set; }

        [Required]
        //Validate phone like: 123-123-1234
        public string Phone { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}