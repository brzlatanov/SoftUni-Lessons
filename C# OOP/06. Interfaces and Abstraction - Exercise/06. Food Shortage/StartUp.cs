using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            List<IBuyer> buyerList = new List<IBuyer>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4) // <name> <age> <id> <birthdate> - citizen
                {
                    buyerList.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                }
                else if (input.Length == 3) // <name> <age><group> - rebel
                {
                    buyerList.Add(new Rebel(input[0], int.Parse(input[1]), input[2])); 
                }
            }

            string nameInput = Console.ReadLine();

            while (nameInput.ToUpper() != "END")
            {
                foreach (var buyer in buyerList)
                {
                    if (buyer.Name == nameInput)
                    {
                        buyer.BuyFood();
                    }
                }

                nameInput = Console.ReadLine();
            }

            int sum = 0;
            foreach (var buyer in buyerList)
            {
                sum += buyer.Food;
            }

            Console.WriteLine(sum);
        }
    }
}
