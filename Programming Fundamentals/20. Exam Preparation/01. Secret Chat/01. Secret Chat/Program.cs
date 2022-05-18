using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder encodedMsg = new StringBuilder(Console.ReadLine());

            string[] command = Console.ReadLine().Split(":|:");

            while (command[0] != "Reveal")
            {
                if (command[0] == "InsertSpace")
                {
                    encodedMsg.Insert(int.Parse(command[1]), " ");
                    Console.WriteLine(encodedMsg);
                }
                else if (command[0] == "Reverse")
                {
                    if (encodedMsg.ToString().Contains(command[1]))
                    {
                        string substring = encodedMsg.ToString().Substring(encodedMsg.ToString().IndexOf(command[1]), command[1].Length);
                        encodedMsg.Remove(encodedMsg.ToString().IndexOf(command[1]), command[1].Length);

                        char[] charArray = substring.ToCharArray();
                        Array.Reverse(charArray);

                        foreach (var item in charArray)
                        {
                            encodedMsg.Append(item);
                        }
                        Console.WriteLine(encodedMsg);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "ChangeAll")
                {
                    if (encodedMsg.ToString().Contains(command[1]))
                    {
                        encodedMsg.Replace(command[1], command[2]);
                    }

                    Console.WriteLine(encodedMsg);
                }

                command = Console.ReadLine().Split(":|:");
            }
            Console.WriteLine($"You have a new text message: {encodedMsg}");
        }
    }
}
