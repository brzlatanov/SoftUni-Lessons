using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ExportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors.Select(a => new AuthorExportDto
            {
                AuthorName = a.FirstName + " " + a.LastName,
                Books = a.AuthorsBooks
                    .OrderByDescending(ab => ab.Book.Price)
                    .Select(ab => new BookExportDto 
                {
                    BookName = ab.Book.Name,
                    BookPrice = ab.Book.Price.ToString("F2")
                }).ToArray()
            }).ToArray();

            authors = authors.OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName).ToArray();

            return JsonConvert.SerializeObject(authors, Formatting.Indented);

        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            OldestBookDto[] books = context.Books
                .ToArray()
                .OrderByDescending(b=> b.Pages)
                .ThenByDescending(b=> b.PublishedOn)
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .Select(b => new OldestBookDto
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                }).Take(10)
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(OldestBookDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            serializer.Serialize(sw, books, ns);

            return sb.ToString();
        }
    }
}