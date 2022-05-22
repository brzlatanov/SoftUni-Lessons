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

            string input = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db, input));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true); 

                var books = context.Books.Where(b => b.AgeRestriction == ageRestriction).OrderBy(b=> b.Title)
                    .Select(b=> b.Title).ToList();

                foreach (var title in books)
                {
                    sb.AppendLine(title);
                }
                
            return sb.ToString().TrimEnd();
        }
    }
}
