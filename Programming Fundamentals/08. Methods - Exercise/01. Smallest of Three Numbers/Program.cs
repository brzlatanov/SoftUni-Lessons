using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int input1 = int.Parse(Console.ReadLine());
            int input2 = int.Parse(Console.ReadLine());
            int input3 = int.Parse(Console.ReadLine());

            Console.WriteLine(PrintSmallest(input1, input2, input3));
        }

        static int PrintSmallest(int input1, int input2, int input3)
        {
            int minNum = 0;

            if (input1 <= input2 && input1 <= input3)
            {
                minNum = input1;
            }
            else if (input2 <= input1 && input2 <= input3)
            {
                minNum = input2;
            }
            else
            {
                minNum = input3;
            }

            return minNum;
        }
    }
}
