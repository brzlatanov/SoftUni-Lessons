using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            int index = 0;

            while (index < list.Count - 1)
            {
                if (list[index] == list[index + 1])
                {
                    list[index] += list[index + 1];
                    list.RemoveAt(index + 1);
                    if (index > 0)
                    {
                        index--;
                    }
                }
                else
                {
                    index++;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
