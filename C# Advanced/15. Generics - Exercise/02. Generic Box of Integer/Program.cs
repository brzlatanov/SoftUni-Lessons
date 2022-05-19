using System;
using System.Collections.Generic;

namespace BoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<int>> itemList = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> currentItem = new Box<int>(input);
                itemList.Add(currentItem);
            }

            foreach (var item in itemList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
