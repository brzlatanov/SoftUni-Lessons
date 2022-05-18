using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            string result = GetMiddleCharacters(inputText);

            Console.WriteLine(result);
        }

        private static string GetMiddleCharacters(string inputText)
        {
            string result = string.Empty;

            if (inputText.Length % 2 == 1)
            {
                result = inputText[inputText.Length / 2].ToString();
            }
            else
            {
                result = inputText[inputText.Length / 2 - 1].ToString();
                result += inputText[inputText.Length / 2];
            }

            return result;
        }
    }
}
