using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputRange = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            List<int> resultList = new List<int>();

            for (int i = inputRange[0]; i <= inputRange[1]; i++)
            {
                resultList.Add(i);
            }

            Predicate<int> evens = input => input % 2 == 0;
            Predicate<int> odds = input => input % 2 != 0;

            string cond = Console.ReadLine();

            switch (cond)
            {
                case "even":
                    resultList = resultList.Where(n => evens(n)).ToList();
                    break;
                case "odd":
                    resultList = resultList.Where(n => odds(n)).ToList();
                    break;
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
