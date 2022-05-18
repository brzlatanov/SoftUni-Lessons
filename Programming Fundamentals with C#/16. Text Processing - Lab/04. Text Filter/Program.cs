using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            string censoredWord = "";

            for (int j = 0; j < banList.Length; j++)
            {
                for (int k = 0; k < banList[j].Length; k++)
                {
                    censoredWord += "*";
                }

                text = text.Replace(banList[j], censoredWord);

                censoredWord = string.Empty;
            }

            Console.WriteLine(text);
        }
    }
}
