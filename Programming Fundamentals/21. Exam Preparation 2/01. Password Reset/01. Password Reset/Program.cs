using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalPassword = Console.ReadLine();

            string[] command = Console.ReadLine().Split(" ");

            StringBuilder sb = new StringBuilder(originalPassword);

            while (command[0] != "Done")
            {
                if (command[0] == "TakeOdd")
                {
                    string oddPass = "";

                    for (int i = 1; i < sb.Length; i += 2)
                    {
                        oddPass += sb[i];

                    }

                    sb.Clear();
                    sb.Append(oddPass);
                    Console.WriteLine(sb);
                }
                else if (command[0] == "Cut")
                {
                    string substring = sb.ToString().Substring(int.Parse(command[1]), int.Parse(command[2]));

                    if (sb.ToString().Contains(substring))
                    {
                        sb.Remove(sb.ToString().IndexOf(substring), substring.Length);
                    }

                    Console.WriteLine(sb);
                }
                else if (command[0] == "Substitute")
                {
                    if (sb.ToString().Contains(command[1]))
                    {
                        sb.Replace(command[1], command[2]);
                        Console.WriteLine(sb);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine().Split(" ");
            }

            Console.WriteLine($"Your password is: {sb}");
        }
    }
}
