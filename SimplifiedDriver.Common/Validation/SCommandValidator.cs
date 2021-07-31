using SimplifiedDriver.Common.Helpers;
using System;
using static SimplifiedDriver.Common.Helpers.Constants;

namespace SimplifiedDriver.Common.Validation
{
    public class SCommandValidator : ValidationDecorator
    {
        public SCommandValidator(Validator validator) : base(validator)
        {
        }
        public override bool Validate(byte[] packetAsciiCodeValues, string packet)
        {
            var packetParamter = Helper.GetPacketParamter(packet);
            if (IsSCommandParamterValid(packetParamter))
                return base.Validate(packetAsciiCodeValues, packet);
            return false;
        }
        public bool IsSCommandParamterValid(string paramter)
        {
            var sCommandParamters = paramter.Split(",");
            if (sCommandParamters != null)
            {
                int frequency;
                Int32.TryParse(sCommandParamters[0], out frequency);
                if (frequency != 0 && frequency >= LOWSET_FRENQUENCY_VALUE && frequency < HIGHEST_FRENQUENCY_VALUE)
                {
                    int duration;
                    Int32.TryParse(sCommandParamters[1], out duration);
                    if (duration != 0)
                        return true;
                }
            }
            return false;
        }
    }
}
