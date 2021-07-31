using SimplifiedDriver.Common.Enums;

namespace SimplifiedDriver.Common.Validation
{
    public abstract class ValidationDecorator : Validator
    {
        protected Validator Validator { get; }
        public ValidationDecorator(Validator validator)
        {
            Validator = validator;
        }
        public override bool IsASCIICharsInRange(string parameter)
        {
            return Validator.IsASCIICharsInRange(parameter);
        }
        public override bool IsASCIICodeValueAsExpected(byte byteAsciiCodeValue, byte acutalAsciiValue)
        {
            return Validator.IsASCIICodeValueAsExpected(byteAsciiCodeValue, acutalAsciiValue);
        }
        public override bool Validate(byte[] packetAsciiCodeValues, string packet)
        {
            return Validator.Validate(packetAsciiCodeValues, packet);
        }
        public override bool IsExistingCommandType(CommandTypeEnum commandType)
        {
            return Validator.IsExistingCommandType(commandType);
        }
    }
}


