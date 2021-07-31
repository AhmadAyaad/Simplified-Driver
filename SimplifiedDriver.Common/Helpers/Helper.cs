using SimplifiedDriver.Common.Enums;
using SimplifiedDriver.Common.Validation;
using System;
namespace SimplifiedDriver.Common.Helpers
{
    public static class Helper
    {
        /// <param name="byteASCIICodeValue">Command type in ASCIICode value.</param>
        public static CommandTypeEnum GetCommandType(byte byteASCIICodeValue)
        {
            return byteASCIICodeValue == (byte)CommandTypeEnum.TCommand
                                            ?
                                            CommandTypeEnum.TCommand : byteASCIICodeValue == (byte)CommandTypeEnum.SCommand
                                            ?
                                            CommandTypeEnum.SCommand : 0;
        }
        /// <param name="packet">Entered packet by the device.</param>
        public static string GetPacketParamter(string packet)
        {
            var packetPayLoad = packet.Split(":");
            return packetPayLoad[1];
        }
        /// <param name="packet">Entered packet by the device.</param>
        /// <param name="packetAsciiCodeValues">Entered packet by the device after conversion.</param>
        /// <param name="validator">Validator reference.</param>
        public static bool IsValidPacket(string packet, byte[] packetAsciiCodeValues, Validator validator)
        {
            if (validator.Validate(packetAsciiCodeValues, packet))
            {
                RespondWithPacketStatus("ACK");
                return true;
            }
            else
                RespondWithPacketStatus("NACK");
            return false;
        }
        /// <param name="value">Packet Status.</param>
        private static void RespondWithPacketStatus(string value)
        {
            Console.WriteLine($"\n{value}");
        }
    }

}
