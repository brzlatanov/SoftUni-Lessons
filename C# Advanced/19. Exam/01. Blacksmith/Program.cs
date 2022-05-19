using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] steelInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .ToArray();

            double[] carbonInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .ToArray();

            Queue<double> steelQueue = new Queue<double>(steelInput);
            Stack<double> carbonStack = new Stack<double>(carbonInput);

            List<Sword> swords = new List<Sword>
            {
                {new Sword("Gladius", 70)}, {new Sword("Shamshir", 80)}, {new Sword("Katana", 90)},
                {new Sword("Sabre", 110)}, {new Sword("Broadsword", 150)}
            };

            while (steelQueue.Any() && carbonStack.Any())
            {
                double result = steelQueue.Peek() + carbonStack.Peek();

                Sword sword = swords.FirstOrDefault(s => s.ResourcesNeeded == result);

                steelQueue.Dequeue();

                if (sword != null)
                {
                    sword.Count++;
                    carbonStack.Pop();
                }
                else
                {
                    carbonStack.Push(carbonStack.Pop() + 5);
                }
            }

            if (swords.Any(s => s.Count > 0))
            {
                Console.WriteLine($"You have forged {swords.Sum(s => s.Count)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steelQueue.Any())
            {
                Console.WriteLine("Steel left: " + string.Join(", ", steelQueue));
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbonStack.Any())
            {
                Console.WriteLine("Carbon left: " + string.Join(", ", carbonStack));
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swords.Where(s => s.Count > 0).OrderBy(s => s.Name))
            {
                Console.WriteLine($"{sword.Name}: {sword.Count}");
            }

        }

        public class Sword
        {
            public string Name { get; set; }
            public double ResourcesNeeded { get; set; }

            public int Count { get; set; }
            public Sword(string name, double resourcesNeeded)
            {
                this.Name = name;
                this.ResourcesNeeded = resourcesNeeded;
                this.Count = 0;
            }
        }
    }
}
