using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Box> boxList = new List<Box>();

            while (command != "end")
            {
                string[] commandArgs = command.Split(" ");
                string serialNumber = commandArgs[0];
                string itemName = commandArgs[1];
                int itemQuantity = int.Parse(commandArgs[2]);
                decimal itemPrice = decimal.Parse(commandArgs[3]);

                Box box = new Box
                {
                    SerialNumber = serialNumber,
                    Quantity = itemQuantity,

                };

                box.Item = new Item
                {
                    Name = itemName,
                    Price = itemPrice
                };

                box.PriceBox = itemQuantity * itemPrice;
                boxList.Add(box);

                command = Console.ReadLine();
            }

            List<Box> sortedList = boxList.OrderBy(o => o.PriceBox).ToList();
            sortedList.Reverse();

            foreach (var box in sortedList)
            {
                Console.WriteLine(string.Join("\n", $"{box.SerialNumber}", $"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}", $"-- ${box.PriceBox:F2}"));
            }
        }
    }
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    }
}
