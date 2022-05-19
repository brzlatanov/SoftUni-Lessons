using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputColor = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string[] inputClothes = inputColor[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(inputColor[0]))
                {
                    clothes.Add(inputColor[0], new Dictionary<string, int>());
                }

                for (int j = 0; j < inputClothes.Length; j++)
                {
                    if (!clothes[inputColor[0]].ContainsKey(inputClothes[j]))
                    {
                        clothes[inputColor[0]].Add(inputClothes[j], 1);
                    }
                    else
                    {
                        clothes[inputColor[0]][inputClothes[j]]++;
                    }
                }
            }

            string[] clothesSearch = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in clothes)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var clothType in item.Value)
                {
                    if (item.Key == clothesSearch[0] && clothType.Key == clothesSearch[1])
                    {
                        Console.WriteLine($"* {clothType.Key} - {clothType.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothType.Key} - {clothType.Value}");
                    }
                }
            }
        }
    }
}
