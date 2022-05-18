using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstarray = Console.ReadLine().Split(' ');
            string[] secondarray = Console.ReadLine().Split(' ');

            string[] result = secondarray.Intersect(firstarray).ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
