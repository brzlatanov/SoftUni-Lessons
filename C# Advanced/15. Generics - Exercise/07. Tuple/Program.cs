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

            CustomTuple<string, string> firstTuple = new CustomTuple<string, string>(firstAndLastName, address);

            string[] secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = secondLine[0];
            int litersBeer = int.Parse(secondLine[1]);

            CustomTuple<string, int> secondTuple = new CustomTuple<string, int>(name, litersBeer);

            string[] thirdLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int thirdLineInteger = int.Parse(thirdLine[0]);
            double thirdLineDouble = double.Parse(thirdLine[1]);

            CustomTuple<int, double> thirdTuple = new CustomTuple<int, double>(thirdLineInteger, thirdLineDouble);

            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());


        }
    }
}
