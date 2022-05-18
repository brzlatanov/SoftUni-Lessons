using System;
using System.Text;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] userNames = Console.ReadLine().Split(", ");
            bool validChar = true;

            for (int i = 0; i < userNames.Length; i++)
            {
                for (int j = 0; j < userNames[i].Length; j++)
                {
                    if (!char.IsNumber(userNames[i][j]) && !char.IsLetter(userNames[i][j]))
                    {
                        validChar = false;
                    }
                    if (userNames[i][j] == '-' || userNames[i][j] == '_')
                    {
                        validChar = true;
                    }
                }
                if (validChar == true && userNames[i].Length >= 3 && userNames[i].Length <= 16)
                {
                    Console.WriteLine(userNames[i]);
                }

                validChar = true;
            }
        }

    }
}
