using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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

            //int input = int.Parse(Console.ReadLine());

            IncreasePrices(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title).ToList();

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
                .Select(b => new { b.Title, b.Price })
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
                    .SelectMany(b => b.BookCategories,
                        (b, bc)
                            => new { b.Title, CategoryName = bc.Category.Name })
                    .Where(bc => categories.Contains(bc.CategoryName.ToUpper()))
                    .OrderBy(b => b.Title)
                    .ToList();

            foreach (var book in booksByCategory)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime dateParsed = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateParsed)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new { b.Title, b.EditionType, b.Price })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { FullName = a.FirstName + ' ' + a.LastName })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToUpper()
                    .Contains(input.ToUpper()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToUpper().StartsWith(input.ToUpper()))
                .OrderBy(b => b.BookId)
                .Select(b => new { BookTitle = b.Title, AuthorFullName = b.Author.FirstName + " " + b.Author.LastName })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCount = context.Books.Count(b => b.Title.Length > lengthCheck);

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {

            StringBuilder sb = new StringBuilder();

            var authorsWithBooks = context.Authors
                .Select(a => new
                { AuthorName = a.FirstName + " " + a.LastName, BookCopies = a.Books.Sum(b => b.Copies) })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            foreach (var author in authorsWithBooks)
            {
                sb.AppendLine($"{author.AuthorName} - {author.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                { CategoryName = c.Name, Profit = c.CategoryBooks.Sum(c => c.Book.Copies * c.Book.Price) })
            .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.CategoryName);

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.CategoryName} ${category.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var recentBooks = context.Categories
                .OrderBy(c => c.Name)
                .SelectMany(c => c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3),
                    (c, b) => new {CategoryName = c.Name, b.Book.Title, b.Book.ReleaseDate})
                .ToList();

            int categoryCounter = 1;
            foreach (var book in recentBooks)
            {
                if (categoryCounter == 1)
                {
                    sb.AppendLine($"--{book.CategoryName}");
                }

                sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");

                categoryCounter++;

                if (categoryCounter == 4)
                {
                    categoryCounter = 1;
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
    }
}
