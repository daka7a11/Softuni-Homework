namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var books = new List<Book>();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportBookDTO[]), new XmlRootAttribute("Books"));

            using (StringReader sr = new StringReader(xmlString))
            {
                var booksDTO = (ImportBookDTO[])serializer.Deserialize(sr);

                foreach (var b in booksDTO)
                {
                    if (!IsValid(b))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime date;
                    bool isDateValid = DateTime.TryParseExact(b.PublishedOn, "MM/dd/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                    if (!isDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Book book = new Book()
                    {
                        Name = b.Name,
                        Genre = (Genre)b.Genre,
                        Price = b.Price,
                        Pages = b.Pages,
                        PublishedOn = date
                    };

                    books.Add(book);
                    sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
                }
                context.AddRange(books);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var authors = new List<Author>();

            var authorsDTO = JsonConvert.DeserializeObject<ImportAuthorDTO[]>(jsonString);

            foreach (var aDto in authorsDTO)
            {
                if (!IsValid(aDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(x => x.Email == aDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = aDto.FirstName,
                    LastName = aDto.LastName,
                    Email = aDto.Email,
                    Phone = aDto.Phone
                };

                foreach (var book in aDto.Books)
                {
                    if (context.Books.Any(b => b.Id == book.Id))
                    {
                        author.AuthorsBooks.Add(new AuthorBook() { Author = author, BookId = (int)book.Id });
                    }
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, (author.FirstName + ' ' + author.LastName),
                                                                         author.AuthorsBooks.Count));

                authors.Add(author);
            }

            context.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static object List<T>()
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}