using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> nameSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                nameSet.Add(Console.ReadLine());
            }

            foreach (var name in nameSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
