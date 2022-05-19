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

            List<double> collection = new List<double>();

            for (int i = 0; i < number; i++)
            {
                double item = double.Parse(Console.ReadLine());
                collection.Add(item);
            }

            double finalValue = double.Parse(Console.ReadLine());

            Console.WriteLine(Box<double>.CompareTo(collection, finalValue));


        }
    }
}
