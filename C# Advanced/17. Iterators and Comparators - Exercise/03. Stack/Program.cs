using System;

namespace CustomStackExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> customStack = new Stack<int>();

            string[] command = Console.ReadLine().Split(new string[]{" ", ", "}, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] == "Push")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        customStack.Push(int.Parse(command[i]));
                    }

                }
                else if (command[0] == "Pop")
                {
                    customStack.Pop();
                }

                command = Console.ReadLine().Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }

            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
