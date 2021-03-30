using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsTokens = args
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = argsTokens[0];

            string[] commandArgs = argsTokens
                .Skip(1)
                .ToArray();

            //Get the assembly in order to get the types
            Assembly assembly = Assembly.GetCallingAssembly();

            //Get all types in the current assembly in order to create instance of the command and call it`s execute() method.
            
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower().StartsWith(commandName.ToLower()));

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type");
            }

            //If the object that we want to create instance of has a constructor we have to give the parameters of this constructor
            //We can do this by creating an array with the parameters like this
            //object[] ctorArgs = new object[2] {"Name" , 17};
            //After that we have to add it when we create the concrete instance.
            //ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType, ctorArgs);

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
