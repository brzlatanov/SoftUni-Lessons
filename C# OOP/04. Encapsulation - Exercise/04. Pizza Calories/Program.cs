using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaNameInput = Console.ReadLine().Split(" ");

                string pizzaName = pizzaNameInput[1];

                Pizza currentPizza = new Pizza(pizzaName, new Dough());

                string[] doughInput = Console.ReadLine().Split(" ");

                Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));

                currentPizza.Dough = dough;

                string[] input = Console.ReadLine().Split(" ");

                while (input[0].ToUpper() != "END")
                {
                    currentPizza.AddTopping(new Topping(input[1], double.Parse(input[2])));

                    input = Console.ReadLine().Split(" ");
                }

                if (currentPizza.ToppingsCount == 0)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                Console.WriteLine($"{currentPizza.Name} - {currentPizza.TotalCalories:F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
