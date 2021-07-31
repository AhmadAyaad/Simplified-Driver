using SimplifiedDriver.Common.Helpers;
using System;
using static SimplifiedDriver.Common.Helpers.Constants;

namespace SimplifiedDriver.Common.Validation
{
    public class SoundCommandValidator : ValidationDecorator
    {
        public SoundCommandValidator(Validator validator) : base(validator)
        {
        }
        public override bool Validate(byte[] packetAsciiCodeValues, string packet)
        {
            var packetParameter = Helper.GetPacketParameter(packet);
            if (packetParameter != null)
            {
                if (IsSCommandParamterValid(packetParameter))
                    return base.Validate(packetAsciiCodeValues, packet);
            }
            return false;
        }
        private bool IsSCommandParamterValid(string parameter)
        {
            if (!parameter.Contains(','))
                return false;
            var sCommandParamters = parameter.Split(",");
            Int32.TryParse(sCommandParamters[0], out int frequency);
            if (frequency == 0 && frequency < LOWSET_FRENQUENCY_VALUE && frequency >= HIGHEST_FREQUENCY_VALUE)
                return false;
            Int32.TryParse(sCommandParamters[1], out int duration);
            return duration != 0;
        }
    }
}
