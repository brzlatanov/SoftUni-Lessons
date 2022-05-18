using System;

namespace _05._Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int textLength = text.Length;

            for (int index = 0; index < textLength; index++)
            {
                Console.WriteLine(text[index]);
            }
        }
    }
}
