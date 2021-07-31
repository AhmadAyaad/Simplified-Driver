using SimplifiedDriver.Command.Commands;
using SimplifiedDriver.Common.Enums;
using SimplifiedDriver.Common.Helpers;
using SimplifiedDriver.Common.ICommand;
using SimplifiedDriver.Common.Models;
using System;

namespace SimplifiedDriver
{
    public class CommandExecutor
    {
        /// <param name="packet">Entered packet by the device.</param>
        /// <param name="commandType">Command type to execute.</param>
        public void ExecuteCommand(string packet, CommandTypeEnum commandType)
        {
            ICommand command;
            switch (commandType)
            {
                case CommandTypeEnum.TCommand:
                    command = new TextCommand();
                    var textCommandPacketParamter = Helper.GetPacketParameter(packet);
                    if (textCommandPacketParamter != null)
                        command.Execute(new BaseCommandInputModel { Message = textCommandPacketParamter });
                    break;
                case CommandTypeEnum.SCommand:
                    command = new SoundCommand();
                    var soundCommandPacketParamter = Helper.GetPacketParameter(packet);
                    if (soundCommandPacketParamter != null && soundCommandPacketParamter.Contains(','))
                    {
                        var commandParamters = soundCommandPacketParamter.Split(",");
                        command.Execute(new SCommandInputModel(Convert.ToInt32(commandParamters[0]), Convert.ToInt32(commandParamters[1])));
                    }
                    break;
                default:
                    command = null;
                    break;
            }
        }
    }
}
