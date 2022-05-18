using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoin = 0;

            string[] input = Console.ReadLine().Split(' ', '|');

            for (int i = 1; i < input.Length; i += 2)
            {
                string roomContent = input[i - 1];
                int roomNumber = int.Parse(input[i]);

                if (roomNumber < 0)
                {
                    roomNumber = 0;
                }

                if (roomContent == "potion")
                {
                    if (health + roomNumber >= 100)
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {roomNumber} hp.");
                        health += roomNumber;
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (roomContent == "chest")
                {
                    bitcoin += roomNumber;
                    Console.WriteLine($"You found {roomNumber} bitcoins.");
                }
                else
                {
                    health -= roomNumber;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {roomContent}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {roomContent}.");
                        Console.WriteLine($"Best room: {(i + 1) / 2}");
                        break;
                    }
                }

            }

            if (health > 0)
            {
                Console.WriteLine(string.Join("\n", "You've made it!", $"Bitcoins: {bitcoin}", $"Health: {health}"));
            }
        }
    }
}
