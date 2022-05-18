using System;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split().Reverse().ToArray();

            Console.WriteLine(string.Join(" ", strings));
        }
    }
}
