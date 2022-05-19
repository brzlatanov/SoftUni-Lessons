using System;

namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ListyIterator<string> iterator = new ListyIterator<string>();

            while (command[0] != "END")
            {
                if (command[0] == "Create")
                {
                    string[] parameters = new string[command.Length - 1];

                    for (int i = 1; i < command.Length; i++)
                    {
                        parameters[i - 1] = command[i];
                    }

                    iterator = new ListyIterator<string>(parameters);
                }

                else if (command[0] == "Move")
                {

                    Console.WriteLine(iterator.Move());
                   // if (iterator.Move())
                   // {
                   //     iterator.Move();
                   //     Console.WriteLine("True");
                   // }
                   // else
                   // {
                   //     Console.WriteLine("False");
                   // }
                }

                else if (command[0] == "Print")
                {
                    iterator.Print();
                }

                else if (command[0] == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }

                else if (command[0] == "PrintAll")
                {
                    iterator.PrintAll();
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            }
        }
    }
}
