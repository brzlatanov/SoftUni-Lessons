using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            bool areBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                char temp = input[i];

                if (temp == '[' || temp == '{' || temp == '(')
                {
                    stack.Push(temp);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        areBalanced = false;
                        break;
                    }

                    char closingBracket = stack.Pop();

                    if ((closingBracket == '{' && temp != '}' || closingBracket == '[' && temp != ']' ||
                         closingBracket == '(' && temp != ')'))
                    {
                        areBalanced = false;
                        break;
                    }
                }
            }

            if (areBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
