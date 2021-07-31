using SimplifiedDriver.Common.ICommand;
using SimplifiedDriver.Common.Models;
using System;

namespace SimplifiedDriver.Command.Commands
{
    public class SoundCommand : ICommand
    {
        public void Execute(BaseCommandInputModel paramters)
        {
            Console.Beep(paramters.Frequency, paramters.Duration);
        }
    }
}
