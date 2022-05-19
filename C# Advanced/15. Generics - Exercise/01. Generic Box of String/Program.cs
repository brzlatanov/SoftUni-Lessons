using System;
using System.Collections.Generic;

namespace BoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> itemList = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> currentItem = new Box<string>(input);
                itemList.Add(currentItem);
            }

            foreach (var item in itemList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
