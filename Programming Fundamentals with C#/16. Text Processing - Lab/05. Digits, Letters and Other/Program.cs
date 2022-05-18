using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder letters = new StringBuilder();
            StringBuilder numbers = new StringBuilder();
            StringBuilder special = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    numbers.Append(input[i]);
                }
                else if (char.IsLetter(input[i]))
                {
                    letters.Append(input[i]);
                }
                else
                {
                    special.Append(input[i]);
                }
            }

            Console.WriteLine(numbers);
            Console.WriteLine(letters);
            Console.WriteLine(special);
        }
    }
}
