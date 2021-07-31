using SimplifiedDriver.Common.Enums;
using SimplifiedDriver.Common.Validation;

namespace SimplifiedDriver
{
    public class ValidatorFactory
    {
        public Validator GetValidatorInstance(CommandTypeEnum commandType)
        {
            Validator validator = new BaseValidator();
            if (commandType == CommandTypeEnum.SCommand)
                validator = new SCommandValidator(validator);
            return validator;
        }
    }
}
