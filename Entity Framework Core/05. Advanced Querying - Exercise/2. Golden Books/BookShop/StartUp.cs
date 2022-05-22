using System;
using System.Linq;
using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;
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
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetGoldenBooks(db));
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
    }
}
