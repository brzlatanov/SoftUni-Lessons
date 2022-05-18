using System;

namespace _06._Foreign_Languages
{
    class Program
    {
        static void Main()
        {
            var language = Console.ReadLine();
            switch (language)
            {
                case "England":
                    Console.WriteLine("English");
                    break;
                case "USA":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                    Console.WriteLine("Spanish");
                    break;
                case "Argentina":
                    Console.WriteLine("Spanish");
                    break;
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;


                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
