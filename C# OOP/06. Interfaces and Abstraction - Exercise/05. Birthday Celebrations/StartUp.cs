using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> birthdateList = new List<string>();

            while (command[0].ToUpper()!= "END")
            {
                if (command[0].ToUpper() == "CITIZEN")
                {
                    birthdateList.Add(command[4]);
                }
                else if (command[0].ToUpper() == "PET")
                {
                    birthdateList.Add(command[2]);
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string yearSuffix = Console.ReadLine();

            birthdateList.Where(x=>x.EndsWith(yearSuffix)).ToList().ForEach(x=> Console.WriteLine(x));
        }
    }
}
