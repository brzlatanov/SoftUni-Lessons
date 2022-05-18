using System;
using System.Linq;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Join("", username.Reverse());
            int passwordTry = 0;

            for (int i = 0; i < 4; i++)
            {
                string inputPassword = Console.ReadLine();
                if (inputPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                else if (inputPassword != password)
                {
                    passwordTry++;
                    if (passwordTry <= 3)
                    {
                        Console.WriteLine($"Incorrect password. Try again.");
                    }

                    if (passwordTry == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                }
            }
        }
    }
}
