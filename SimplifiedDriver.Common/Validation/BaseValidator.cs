using SimplifiedDriver.Common.Enums;
using SimplifiedDriver.Common.Helpers;
using System.Linq;
using static SimplifiedDriver.Common.Helpers.Constants;

namespace SimplifiedDriver.Common.Validation
{
    public class BaseValidator : Validator
    {
        public override bool IsASCIICharsInRange(string paramter)
        {
            return paramter.ToCharArray().All(p => p >= START_ASCII_CODE_RANGE_VALUE && p <= END_ASCII_CODE_RANGE_VALUE);
        }
        public override bool IsASCIICodeValueAsExpected(byte byteASCIICodeValue, byte acutalASCIIValue)
        {
            return byteASCIICodeValue == acutalASCIIValue ? true : false;
        }
        public override bool IsExistingCommandType(CommandTypeEnum commandType)
        {
            return (commandType != CommandTypeEnum.TCommand && commandType != CommandTypeEnum.SCommand) ? false : true;
        }

        public override bool Validate(byte[] packesAsciiCodeValues, string packet)
        {
            //First Char(P)
            if (IsASCIICodeValueAsExpected(packesAsciiCodeValues[0], P_CHAR_ASCII_CODE_VALUE))
            {
                //Last Char(E)
                if (IsASCIICodeValueAsExpected(packesAsciiCodeValues[packesAsciiCodeValues.Length - 1], E_CHAR_ASCII_CODE_VALUE))
                {
                    //Last colon(:) in packet
                    if (IsASCIICodeValueAsExpected(packesAsciiCodeValues[packesAsciiCodeValues.Length - 2], COLON_CHAR_ASCII_CODE_VALUE))
                    {
                        //First colon(:) in packet
                        if (IsASCIICodeValueAsExpected(packesAsciiCodeValues[2], COLON_CHAR_ASCII_CODE_VALUE))
                        {
                            var commandType = Helper.GetCommandType(packesAsciiCodeValues[1]);
                            //See if command is existing
                            if (IsExistingCommandType(commandType))
                                //Packet paramter
                                return IsASCIICharsInRange(Helper.GetPacketParamter(packet));
                        }
                    }
                }
            }
            return false;
        }
    }
}