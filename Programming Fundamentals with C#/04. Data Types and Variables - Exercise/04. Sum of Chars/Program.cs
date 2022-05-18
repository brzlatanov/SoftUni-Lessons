using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                char m = char.Parse(Console.ReadLine());
                counter += (int)m;

            }

            Console.WriteLine($"The sum equals: {counter}");
        }
    }
}
