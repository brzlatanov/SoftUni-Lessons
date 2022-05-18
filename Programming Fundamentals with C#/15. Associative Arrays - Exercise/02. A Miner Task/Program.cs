using System;
using System.Collections.Generic;
using System.Text;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourceDict = new Dictionary<string, int>();

            string resource = Console.ReadLine();
            int resourceQuantity = int.Parse(Console.ReadLine());

            while (true)
            {
                if (!resourceDict.ContainsKey(resource))
                {
                    resourceDict.Add(resource, resourceQuantity);
                }
                else
                {
                    resourceDict[resource] += resourceQuantity;
                }

                resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                resourceQuantity = int.Parse(Console.ReadLine());
            }

            foreach (var resourceType in resourceDict)
            {
                Console.WriteLine($"{resourceType.Key} -> {resourceType.Value}");
            }
        }
    }
}
