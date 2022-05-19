using System;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stringStack = new Stack<char>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                stringStack.Push(input[i]);
            }

            while (stringStack.Count > 0)
            {
                Console.Write(stringStack.Pop());
            }
        }
    }
}
