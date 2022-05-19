using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            Action<string> print = n => Console.WriteLine(n);

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}
