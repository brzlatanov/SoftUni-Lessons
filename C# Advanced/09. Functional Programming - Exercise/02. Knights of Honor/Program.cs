using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            Action<string> print = n => Console.WriteLine($"Sir" + " " + n);

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}
