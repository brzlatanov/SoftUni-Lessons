using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            Console.WriteLine(orders.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                if (quantity >= orders[i])
                {
                    quantity -= orders[i];
                    ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (!ordersQueue.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write($"Orders left: ");
                Console.WriteLine(string.Join(" ", ordersQueue));
            }
        }
    }
}
