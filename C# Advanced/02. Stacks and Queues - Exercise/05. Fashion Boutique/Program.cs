using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] clothesInBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            clothesInBox = clothesInBox.Where(x => x > 0).ToArray();
            uint rackCapacity = uint.Parse(Console.ReadLine());

            Stack<int> clothesStack = new Stack<int>(clothesInBox);
            int rackCounter = 0;
            int clothesSum = 0;

            while (clothesStack.Count > 0)
            {
                if (rackCapacity == 0)
                {
                    Console.WriteLine("0");
                    return;
                }

                CheckRackCapacity(rackCapacity, clothesStack, ref rackCounter, ref clothesSum);

            }

            if (clothesSum > 0)
            {
                rackCounter++;
            }

            Console.WriteLine(rackCounter);
        }

        private static void CheckRackCapacity(uint rackCapacity, Stack<int> clothesStack, ref int rackCounter, ref int clothesSum)
        {
            if (rackCapacity > clothesSum + clothesStack.Peek())
            {
                clothesSum += clothesStack.Pop();
            }
            else if (rackCapacity == clothesSum + clothesStack.Peek())
            {
                if (clothesStack.Count > 0)
                {
                    clothesSum = 0;
                    clothesStack.Pop();
                    rackCounter++;
                }

            }
            else if (rackCapacity < clothesSum + clothesStack.Peek())
            {
                clothesSum = clothesStack.Pop();
                rackCounter++;
            }
        }
    }
}
