using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            int sum4 = 0;
            int sum5 = 0;


            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a')
                {
                    sum1 += 1;
                }
                else if (text[i] == 'e')
                {
                    sum2 += 2;
                }
                else if (text[i] == 'i')
                {
                    sum3 += 3;
                }
                else if (text[i] == 'o')
                {
                    sum4 += 4;
                }
                else if (text[i] == 'u')
                {
                    sum5 += 5;
                }

            }
            int finalSum = (sum1 + sum2 + sum3 + sum4 + sum5);
            Console.WriteLine(finalSum);
        }

    }
}
