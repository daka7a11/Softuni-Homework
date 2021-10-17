﻿
using System.Collections.Generic;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
            CategoryBooks = new HashSet<BookCategory>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<BookCategory> CategoryBooks { get; set; }
    }
}
