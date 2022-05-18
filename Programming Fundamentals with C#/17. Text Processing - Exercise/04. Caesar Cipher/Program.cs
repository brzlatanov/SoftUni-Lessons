using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char character = ' ';

            StringBuilder encryptedInput = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                character = (char)(input[i] + 3);
                encryptedInput.Append(character);
            }

            Console.WriteLine(encryptedInput);
        }

    }
}
