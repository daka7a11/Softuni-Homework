using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;
namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND = "command";
        public string Read(string args)
        {
                        string[] inputTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandType = inputTokens[0].ToLower() + COMMAND;
            string[] commandArgs = inputTokens.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(t => (t.Name).ToLower() == commandType);

            if (type == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            string result = instance.Execute(commandArgs);

            return result;
        }
    }
}
