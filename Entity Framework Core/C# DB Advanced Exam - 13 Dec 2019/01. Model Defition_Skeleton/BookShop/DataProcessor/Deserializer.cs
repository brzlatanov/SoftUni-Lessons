using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;

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
            XmlRootAttribute root = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportBookDto[]), root);

            ICollection<ImportBookDto> bookDtos;

            using (StringReader sr = new StringReader(xmlString)) 
            {
                bookDtos = (ImportBookDto[]) serializer.Deserialize(sr);
            }

            StringBuilder sb = new StringBuilder();
            List<Book> books = new List<Book>();

            foreach (var bookDto in bookDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (!Enum.IsDefined(typeof(Genre), bookDto.Genre))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (!DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Book book = new Book()
                {
                    Genre = (Genre)(bookDto.Genre),
                    Name = bookDto.Name,
                    Pages = bookDto.Pages,
                    Price = bookDto.Price,
                    PublishedOn = result 
                };

                books.Add(book);
                sb.AppendLine($"Successfully imported book {bookDto.Name} for {bookDto.Price:F2}.");
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString); 
            StringBuilder sb = new StringBuilder();

            List<Author> authors = new List<Author>();

            foreach (var authorDto in authorDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (authors.Any(a=> a.Email == authorDto.Email))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email
                };

                foreach (var book in authorDto.Books)
                {
                    if (book.Id == null)
                    {
                        continue;
                    }
                    if (!context.Books.Any(b=> b.Id == book.Id))
                    {
                        continue;
                    }

                    Book currentBook = context.Books.First(b => b.Id == book.Id);

                    author.AuthorsBooks.Add(new AuthorBook()
                    {
                        AuthorId = author.Id,
                        BookId = currentBook.Id
                    });
                }

                if (!author.AuthorsBooks.Any())
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(
                    $"Successfully imported author - {author.FirstName} {author.LastName} with {author.AuthorsBooks.Count} books.");
            }


            context.Authors.AddRange(authors);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}