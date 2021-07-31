using SimplifiedDriver.Common.Enums;

namespace SimplifiedDriver.Common.Validation
{
    public abstract class Validator
    {
        public abstract bool IsASCIICodeValueAsExpected(byte byteASCIICodeValue, byte acutalASCIIValue);
        public abstract bool IsASCIICharsInRange(string paramter);
        public abstract bool Validate(byte[] packetAsciiCodeValues, string packet);
        public abstract bool IsExistingCommandType(CommandTypeEnum commandType);
    }
}
