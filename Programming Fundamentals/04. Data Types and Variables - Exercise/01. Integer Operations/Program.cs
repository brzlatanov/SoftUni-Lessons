using System;

namespace _01._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer1 = int.Parse(Console.ReadLine());
            int integer2 = int.Parse(Console.ReadLine());
            int integer3 = int.Parse(Console.ReadLine());
            int integer4 = int.Parse(Console.ReadLine());
            Console.WriteLine(((integer1 + integer2) / integer3) * integer4);
        }
    }
}
