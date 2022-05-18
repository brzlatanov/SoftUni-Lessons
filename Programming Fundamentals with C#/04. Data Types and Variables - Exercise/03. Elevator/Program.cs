using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte persons = sbyte.Parse(Console.ReadLine());
            sbyte capacity = sbyte.Parse(Console.ReadLine());
            sbyte courses = 0;

            while (persons > 0)
            {
                persons -= capacity;
                courses++;
            }

            Console.WriteLine(courses);
        }
    }
}
