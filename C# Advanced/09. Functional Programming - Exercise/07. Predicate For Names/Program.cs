using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ").ToList();

            Func<string, bool> nameLength = name => name.Length <= n;

            names.Where(nameLength).ToList().ForEach(name => Console.WriteLine(name));
        }
    }
}
