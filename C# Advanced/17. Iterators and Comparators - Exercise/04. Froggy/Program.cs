using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(input);

            var enumerator = lake.GetEnumerator();
            var secondEnumerator = lake.SecondEnumerator();

            List<int> firstEnumResult = new List<int>();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                firstEnumResult.Add(item);
            }

            List<int> secondEnumResult = new List<int>();
            while (secondEnumerator.MoveNext())
            {
                var item = secondEnumerator.Current;
                secondEnumResult.Add(item);
            }

            firstEnumResult.AddRange(secondEnumResult);

            Console.WriteLine(string.Join(", ", firstEnumResult));

        }
    }
}
