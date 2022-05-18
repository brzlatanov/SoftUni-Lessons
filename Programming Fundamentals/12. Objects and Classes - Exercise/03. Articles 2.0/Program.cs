using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articleList = new List<Article>();
            int articleNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < articleNumber; i++)
            {
                string[] article = Console.ReadLine().Split(", ");

                Article articleObject = new Article(article[0], article[1], article[2]);

                articleList.Add(articleObject);
            }

            string typeToFilter = Console.ReadLine();

            if (typeToFilter == "title")
            {
                articleList = articleList.OrderBy(articleObject => articleObject.Title).ToList();
                PrintArticle(articleList);
            }
            if (typeToFilter == "content")
            {
                articleList = articleList.OrderBy(articleObject => articleObject.Content).ToList();
                PrintArticle(articleList);
            }
            if (typeToFilter == "author")
            {
                articleList = articleList.OrderBy(articleObject => articleObject.Author).ToList();
                PrintArticle(articleList);
            }
        }

        private static void PrintArticle(List<Article> articleList)
        {
            Console.WriteLine(String.Join("\n", articleList));
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Author = author;
            Content = content;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
