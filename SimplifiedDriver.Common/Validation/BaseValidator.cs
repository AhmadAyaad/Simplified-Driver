using SimplifiedDriver.Common.Enums;
using SimplifiedDriver.Common.Helpers;
using System.Linq;
using static SimplifiedDriver.Common.Helpers.Constants;

namespace SimplifiedDriver.Common.Validation
{
    public class BaseValidator : Validator
    {
        public override bool IsASCIICharsInRange(string parameter)
        {
            return parameter.ToCharArray().All(p => p >= START_ASCII_CODE_RANGE_VALUE && p <= END_ASCII_CODE_RANGE_VALUE);
        }
        public override bool IsASCIICodeValueAsExpected(byte byteASciiCodeValue, byte actualAsciiValue)
        {
            return byteASciiCodeValue == actualAsciiValue;
        }
        public override bool IsExistingCommandType(CommandTypeEnum commandType)
        {
            return (commandType == CommandTypeEnum.TCommand || commandType == CommandTypeEnum.SCommand);
        }

        public override bool Validate(byte[] packetAsciiCodeValues, string packet)
        {
            //First Char(P)
            if (IsASCIICodeValueAsExpected(packetAsciiCodeValues[0], P_CHAR_ASCII_CODE_VALUE))
            {
                //Last Char(E)
                if (IsASCIICodeValueAsExpected(packetAsciiCodeValues[packetAsciiCodeValues.Length - 1], E_CHAR_ASCII_CODE_VALUE))
                {
                    //Last colon(:) in packet
                    if (IsASCIICodeValueAsExpected(packetAsciiCodeValues[packetAsciiCodeValues.Length - 2], COLON_CHAR_ASCII_CODE_VALUE))
                    {
                        //First colon(:) in packet
                        if (IsASCIICodeValueAsExpected(packetAsciiCodeValues[2], COLON_CHAR_ASCII_CODE_VALUE))
                        {
                            var commandType = Helper.GetCommandType(packetAsciiCodeValues[1]);
                            //See if command is existing
                            if (IsExistingCommandType(commandType))
                            {
                                //Packet parameter
                                var parameter = Helper.GetPacketParameter(packet);
                                if (parameter != null)
                                    return IsASCIICharsInRange(parameter);

                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}