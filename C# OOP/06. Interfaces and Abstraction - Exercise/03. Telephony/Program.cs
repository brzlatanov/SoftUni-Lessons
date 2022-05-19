using System;
using System.Linq;

namespace Phones
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbersInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbersInput.Length; i++)
            {
                if (!phoneNumbersInput[i].All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (phoneNumbersInput[i].Length == 10)
                {
                    smartphone.Call(phoneNumbersInput[i]);
                }
                else if (phoneNumbersInput[i].Length == 7)
                {
                    stationaryPhone.Dial(phoneNumbersInput[i]);
                }
            }
            string[] websitesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < websitesInput.Length; i++)
            {
                if (websitesInput[i].Any(char.IsNumber))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                
                smartphone.Browse(websitesInput[i]);
            }
        }
    }
}
