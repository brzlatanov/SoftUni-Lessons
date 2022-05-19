using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customerQueue = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Paid")
                {
                    Console.WriteLine(string.Join("\n", customerQueue));
                    customerQueue.Clear();
                }
                else
                {
                    customerQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{customerQueue.Count} people remaining.");
        }
    }
}
