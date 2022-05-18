using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ");

            Dictionary<string, List<string>> employeeDict = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                if (!employeeDict.ContainsKey(input[0]))
                {
                    employeeDict.Add(input[0], new List<string>());

                }

                if (!employeeDict[input[0]].Contains(input[1]))
                {
                    employeeDict[input[0]].Add(input[1]);
                }

                input = Console.ReadLine().Split(" -> ");
            }

            employeeDict = employeeDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var company in employeeDict)
            {
                Console.WriteLine(company.Key);

                foreach (var employeeID in company.Value)
                {
                    Console.WriteLine($"-- {employeeID}");
                }
            }
        }
    }
}
