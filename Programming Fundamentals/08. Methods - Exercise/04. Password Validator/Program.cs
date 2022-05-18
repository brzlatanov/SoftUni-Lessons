using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            CheckIfPasswordIsValid(password);
        }

        private static void CheckIfPasswordIsValid(string password)
        {
            bool isValidLength = password.Length >= 6 && password.Length <= 10;

            bool isValidSymbols = true;

            int digitCounter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    isValidSymbols = false;
                }

                if (char.IsDigit(password[i]))
                {
                    digitCounter++;
                }
            }

            bool containsTwoDigits = digitCounter >= 2;

            if (!isValidLength)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!isValidSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!containsTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isValidLength && isValidSymbols && containsTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
