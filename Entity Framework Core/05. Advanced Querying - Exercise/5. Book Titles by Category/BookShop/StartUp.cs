using System;
using System.Linq;
using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string bookCategories = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(db, bookCategories));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true); 

                var books = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b=> b.Title)
                    .Select(b=> b.Title).ToList();

                foreach (var title in books)
                {
                    sb.AppendLine(title);
                }
                
            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            EditionType editionType = EditionType.Gold;

            int copyCount = 5000;

            var books = context.Books
                .Where(b => b.EditionType == editionType)
                .Where(b => b.Copies < copyCount)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title).ToList();

            foreach (var bookTitle in books)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            decimal price = 40.00M;

            StringBuilder sb = new StringBuilder();

            var bookTitlesWithPrice = context.Books
                .Where(b => b.Price > price)
                .Select(b => new {b.Title, b.Price})
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in bookTitlesWithPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var booksNotReleasedIn = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var bookTitle in booksNotReleasedIn)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
                
            string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToUpper()).ToArray();

            var booksByCategory =
                context.Books
                    .SelectMany(b=> b.BookCategories,
                        (b, bc) 
                            => new {b.Title, CategoryName = bc.Category.Name})
                    .Where(bc => categories.Contains(bc.CategoryName.ToUpper()))
                    .OrderBy(b=>b.Title)
                    .ToList();

            foreach (var book in booksByCategory)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
