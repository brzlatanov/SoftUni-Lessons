using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GenericSwapMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> collection = new List<string>();

            for (int i = 0; i < number; i++)
            {
                string item = Console.ReadLine();
                collection.Add(item);
            }

            string finalValue = Console.ReadLine();

            Console.WriteLine(Box<string>.CompareTo(collection, finalValue));


        }
    }
}
