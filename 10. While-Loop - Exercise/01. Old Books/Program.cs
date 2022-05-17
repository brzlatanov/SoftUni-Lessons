using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string book2;
            int bookCount = -1;
            while (true)
            {
                book2 = Console.ReadLine();
                bookCount += 1;
                if (book2 == book)
                {
                    Console.WriteLine($"You checked {bookCount} books and found it.");
                    break;
                }
                else if (book2 == "No More Books")
                {
                    Console.WriteLine($"The book you search is not here!");
                    Console.WriteLine($"You checked {bookCount} books.");
                    break;
                }
            }
        }
    }
}
