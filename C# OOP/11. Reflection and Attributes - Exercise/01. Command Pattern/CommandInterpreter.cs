using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputInfo = args.Split();

            string commandName = inputInfo[0] + "Command";
            string[] parameters = inputInfo.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == commandName).FirstOrDefault();

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            ICommand command = (ICommand)Activator.CreateInstance(type);

            string result = command.Execute(parameters);

            return result;

        }
    }
}