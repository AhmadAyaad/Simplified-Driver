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
            ProcessPacket();
        }

        private static void ProcessPacket()
        {
            var packetAsciiCodeValues = ReadPacketStream();
            var packet = Encoding.UTF8.GetString(packetAsciiCodeValues);
            var commandType = Helper.GetCommandType(packetAsciiCodeValues[1]);//Command Type
            ValidatorFactory validatorFactory = new ValidatorFactory();
            Validator validator = validatorFactory.GetValidatorInstance(commandType);
            if (Helper.IsValidPacket(packet, packetAsciiCodeValues, validator))
                new CommandExecutor().ExecuteCommand(packet, commandType);
            ProcessPacket();
        }

        private static byte[] ReadPacketStream()
        {
            byte[] packetsAsciiCodeValues;
            int colonCounter = 0;
            int maxColonCounter = 2;
            bool valid = false;
            List<char> packetChars = new List<char>();
            do
            {
                var packet = Console.ReadKey();
                if (packet.KeyChar == COLON_CHAR_ASCII_CODE_VALUE)
                    colonCounter++;
                packetChars.Add(packet.KeyChar);
                packetsAsciiCodeValues = Encoding.ASCII.GetBytes(packetChars.ToArray());
                if (packetsAsciiCodeValues.Length > 1)
                    valid = packetsAsciiCodeValues[packetsAsciiCodeValues.Length - 1] == E_CHAR_ASCII_CODE_VALUE
                            && packetsAsciiCodeValues[packetsAsciiCodeValues.Length - 2] == COLON_CHAR_ASCII_CODE_VALUE
                            && colonCounter >= maxColonCounter;
                //Should terminate while there is an E char which is prefixed with 2 colons.
            } while (!valid);
            return packetsAsciiCodeValues;
        }
    }
}
