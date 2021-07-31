using SimplifiedDriver.Common.Enums;

namespace SimplifiedDriver.Common.Validation
{
    public abstract class Validator
    {
        public abstract bool IsASCIICodeValueAsExpected(byte byteAsciiCodeValue, byte actualAsciiValue);
        public abstract bool IsASCIICharsInRange(string parameter);
        public abstract bool Validate(byte[] packetAsciiCodeValues, string packet);
        public abstract bool IsExistingCommandType(CommandTypeEnum commandType);
    }
}
