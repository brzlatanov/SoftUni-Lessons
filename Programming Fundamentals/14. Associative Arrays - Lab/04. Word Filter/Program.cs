using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split().Where(w => w.Length % 2 == 0).ToArray();

            Console.WriteLine(String.Join("\n", array));
        }
    }
}
