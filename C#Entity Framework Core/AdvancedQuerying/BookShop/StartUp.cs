using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();

            IncreasePrices(context);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitles = context.Books
                .ToList()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var b in bookTitles)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenBooks = context
                .Books
                .Where(b => b.Copies < 5000)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var b in goldenBooks)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var titles = context.Books
                .Where(b => b.ReleaseDate.Year != year)
                .OrderByDescending(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var t in titles)
            {
                sb.AppendLine(t);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var categories = input.Split(" ");

            List<string> titles = new List<string>();

            foreach (var category in categories)
            {
                var bookTitles = context.BookCategories
                    .Where(x => x.Category.Name == category)
                    .Select(x => x.Book.Title)
                    .ToList();

                titles.AddRange(bookTitles);
            }

            foreach (var title in titles.OrderBy(x => x))
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string strDate)
        {
            StringBuilder sb = new StringBuilder();

            DateTime date = DateTime.Parse(strDate);

            var books = context.Books
                .Where(b => b.ReleaseDate < date)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    EditionType = b.EditionType.ToString(),
                    b.Price
                })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var fullNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .ToList();

            foreach (var x in fullNames.OrderBy(n => n.FullName))
            {
                sb.AppendLine(x.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var titles = context.Books
                .Where(b => b.Title.Contains(input))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var t in titles)
            {
                sb.AppendLine(t);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var titlesAndAuthNames = context.Books
                .Where(b => b.Author.LastName.StartsWith(input))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorName = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .ToList();

            foreach (var x in titlesAndAuthNames)
            {
                sb.AppendLine($"{x.Title} ({x.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    CopiesCount = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.CopiesCount)
                .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName} - {a.CopiesCount}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(cb => cb.Book)
                })
                .Select(x => new
                {
                    x.Name,
                    TotalProfit = x.Books.Select(x => x.Copies / x.Price).Sum()
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var c in categories)
            {
                sb.AppendLine($"{c.Name} ${c.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks.Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        BookReleaseDate = cb.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.BookReleaseDate)
                    .Take(3)
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            foreach (var c in categories)
            {
                sb.AppendLine($"--{c.CategoryName}");
                foreach (var b in c.Books)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.BookReleaseDate.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Year < 2010).ToList();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }
    }
}
