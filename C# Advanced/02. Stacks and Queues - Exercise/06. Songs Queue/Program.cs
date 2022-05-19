using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialSongs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songQueue = new Queue<string>(initialSongs);

            while (songQueue.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    songQueue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    command = command.Remove(command.IndexOf("Add"), 4);
                    if (!songQueue.Contains(command))
                    {
                        songQueue.Enqueue(command);
                    }
                    else
                    {
                        Console.WriteLine($"{command} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
