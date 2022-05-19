using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._TriFunction
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<int, int, bool> countFunc = (s, n) => s >= n;

            foreach (var name in names)
            {
                if (Count(name, n, countFunc))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }

        public static bool Count(string name, int n, Func<int, int, bool> countFunc)
        {
            int nameCount = 0;

            for (int i = 0; i < name.Length; i++)
            {
                nameCount += (int)(name[i]);
            }

            bool checkSize = false;

            return countFunc(nameCount, n);
        }
    }
}
