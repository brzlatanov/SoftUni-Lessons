using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int people = int.Parse(Console.ReadLine());

                array[i] = people;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
                sum += array[i];
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
