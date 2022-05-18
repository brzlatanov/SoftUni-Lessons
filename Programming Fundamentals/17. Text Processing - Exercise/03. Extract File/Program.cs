using System;
using System.Text;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("\\");
            string[] finalFile = input[input.Length - 1].Split(".");
            Console.WriteLine(string.Join("\n", $"File name: {finalFile[0]}", $"File extension: {finalFile[1]}"));
        }
    }
}
