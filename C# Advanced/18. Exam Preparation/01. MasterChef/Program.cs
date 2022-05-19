using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MasterChef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> ingredientQueue = new Queue<int>();

            for (int i = 0; i < ingredientArray.Length; i++)
            {
                ingredientQueue.Enqueue(ingredientArray[i]);
            }

            int[] freshnessArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> freshnessStack = new Stack<int>();

            for (int i = 0; i < freshnessArray.Length; i++)
            {
                freshnessStack.Push(freshnessArray[i]);
            }

            while (ingredientQueue.Any() && freshnessStack.Any())
            {
                if (ingredientQueue.Peek() == 0)
                {
                    ingredientQueue.Dequeue();
                    continue;
                }

                if (Dishes.dishesList.FirstOrDefault(d => d.Freshness == ingredientQueue.Peek() * freshnessStack.Peek()) != null)
                {
                    Dishes.dishesList.FirstOrDefault(d => d.Freshness == ingredientQueue.Peek() * freshnessStack.Peek())
                        .Quantity++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop();
                }
                else
                {
                    freshnessStack.Pop();
                    ingredientQueue.Enqueue(ingredientQueue.Dequeue() + 5);
                }
            }

            if (Dishes.dishesList.TrueForAll(d => d.Quantity >= 1))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredientQueue.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredientQueue.Sum()}");
            }

            foreach (var dish in Dishes.dishesList.OrderBy(d => d.Name).Where(d => d.Quantity >= 1))
            {
                Console.WriteLine($" # {dish.Name} --> {dish.Quantity}");
            }
        }
    }

    class Dishes
    {
        public static List<Dishes> dishesList = new List<Dishes> { new Dishes("Dipping sauce", 150), new Dishes("Green salad", 250), new Dishes("Chocolate cake", 300), new Dishes("Lobster", 400) };

        public string Name { get; set; }
        public int Freshness { get; set; }
        public int Quantity { get; set; }

        public Dishes(string name, int freshness)
        {
            Name = name;
            Freshness = freshness;
            Quantity = 0;
        }
    }
}