using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            bool result;
            result = Char.IsUpper(a);

            if (result)
            {
                Console.WriteLine("upper-case");
            }
            else if (!result)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
