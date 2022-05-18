using System;

namespace _10._Multiplication_Table
{
    class Program
    {
        static void Main()
        {
            int integer = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{integer} X {i} = {integer * i}");
            }
        }
    }
}
