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

            List<string> idList = new List<string>();

            while (command[0].ToUpper()!= "END")
            {
                if (command.Length == 3)
                {
                    idList.Add(command[2]);
                }
                else if (command.Length == 2)
                {
                    idList.Add(command[1]);
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string idSuffix = Console.ReadLine();

            idList.Where(x=>x.EndsWith(idSuffix)).ToList().ForEach(x=> Console.WriteLine(x));
           
           
        }
    }
}
