using SimplifiedDriver.Common.Helpers;
using SimplifiedDriver.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using static SimplifiedDriver.Common.Helpers.Constants;

namespace SimplifiedDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            var packetAsciiCodeValues = ReadPacketStream();
            var packet = Encoding.UTF8.GetString(packetAsciiCodeValues);
            var commandType = Helper.GetCommandType(packetAsciiCodeValues[1]);//Command Type
            ValidatorFactory validatorFactory = new ValidatorFactory();
            Validator validator = validatorFactory.GetValidatorInstance(commandType);
            if (Helper.IsValidPacket(packet, packetAsciiCodeValues, validator))
                new CommandExecutor().ExecuteCommand(packet, commandType);
        }
        private static byte[] ReadPacketStream()
        {
            byte[] packetsAsciiCodeValues;
            List<char> packetChars = new List<char>();
            do
            {
                var packet = Console.ReadKey();
                packetChars.Add(packet.KeyChar);
                packetsAsciiCodeValues = Encoding.ASCII.GetBytes(packetChars.ToArray());
            } while (packetsAsciiCodeValues[packetsAsciiCodeValues.Length - 1] != E_CHAR_ASCII_CODE_VALUE);
            return packetsAsciiCodeValues;
        }
    }
}
