using System;
using System.Linq;

namespace GenericSwapMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Collection<string> collection = new Collection<string>();

            for (int i = 0; i < number; i++)
            {
                string item = Console.ReadLine();
                collection.Add(item);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int indexOne = indexes[0];
            int indexTwo = indexes[1];

            collection.Swap(indexOne, indexTwo);

            collection.ToString();
        }
    }
}
