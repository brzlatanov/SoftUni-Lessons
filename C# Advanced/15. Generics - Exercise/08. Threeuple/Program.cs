using System;

namespace TupleExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstAndLastName = firstLine[0] + " " + firstLine[1];
            string address = firstLine[2];
            string town = null;

            for (int i = 3; i < firstLine.Length; i++)
            {
                town += firstLine[i] + " ";
            }

            town = town.Trim();

            CustomTuple<string, string, string> firstTuple =
                new CustomTuple<string, string, string>(firstAndLastName, address, town);

            string[] secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = secondLine[0];
            string litersOfBeer = secondLine[1];
            string drunkOrNot = secondLine[2];

            if (drunkOrNot.ToLower() != "drunk")
            {
                drunkOrNot = "False";
            }
            else
            {
                drunkOrNot = "True";
            }

            CustomTuple<string, double, string> secondTuple =
                new CustomTuple<string, double, string>(name, double.Parse(litersOfBeer), drunkOrNot);

            string[] thirdLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string thirdLineName = thirdLine[0];
            string accountBalance = thirdLine[1];
            string bankName = thirdLine[2];

            CustomTuple<string, double, string> thirdTuple =
                new CustomTuple<string, double, string>(thirdLineName, double.Parse(accountBalance), bankName);

            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());


        }
    }
}
