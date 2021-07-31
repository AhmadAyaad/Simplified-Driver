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
        public override bool IsASCIICharsInRange(string paramter)
        {
            return Validator.IsASCIICharsInRange(paramter);
        }
        public override bool IsASCIICodeValueAsExpected(byte byteASCIICodeValue, byte acutalASCIIValue)
        {
            return Validator.IsASCIICodeValueAsExpected(byteASCIICodeValue, acutalASCIIValue);
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


