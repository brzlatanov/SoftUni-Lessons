using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] split = new string[list1.Count];
            List<string> intList = new List<string>();
         
            for (int i = list1.Count - 1; i >= 0; i--)
            {
                list1.Insert(0, list1[list1.Count - 1]);
                list1.RemoveAt(list1.Count - 1);

            }

            list1.Reverse();
          
            for (int i = 0; i < list1.Count; i++)
            {
                split = list1[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < split.Length; j++)
                {
                    intList.Add(split[j]);
                }
            }

            Console.WriteLine(string.Join(" ", intList));
        }
    }
}
