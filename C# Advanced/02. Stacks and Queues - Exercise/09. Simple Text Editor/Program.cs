using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<char> textStack = new Stack<char>();
            Stack<string> tempStack = new Stack<string>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "1")
                {
                    foreach (var element in textStack)
                    {
                        sb.Append(element);
                    }

                    tempStack.Push(sb.ToString());
                    sb.Clear();

                    for (int j = 0; j < command[1].Length; j++)
                    {
                        textStack.Push(command[1][j]);
                    }
                }
                else if (command[0] == "2")
                {
                    foreach (var element in textStack)
                    {
                        sb.Append(element);
                    }

                    tempStack.Push(sb.ToString());
                    sb.Clear();

                    for (int j = 0; j < int.Parse(command[1]); j++)
                    {
                        textStack.Pop();
                    }
                }
                else if (command[0] == "3")
                {
                    Console.WriteLine(textStack.Reverse().ElementAt(int.Parse(command[1]) - 1));
                }
                else if (command[0] == "4")
                {
                    textStack.Clear();

                    for (int k = tempStack.Peek().Length - 1; k >= 0; k--)
                    {
                        textStack.Push(tempStack.Peek()[k]);
                    }

                    tempStack.Pop();
                }
            }
        }
    }
}
