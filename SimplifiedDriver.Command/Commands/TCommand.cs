using SimplifiedDriver.Common.ICommand;
using SimplifiedDriver.Common.Models;
using System;

namespace SimplifiedDriver.Command.Commands
{
    public class TCommand : ICommand
    {
        public void Execute(BaseCommandInputModel data)
        {
            Console.WriteLine(data);
        }
    }
}
