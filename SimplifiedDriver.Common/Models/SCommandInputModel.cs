namespace SimplifiedDriver.Common.Models
{
    public class SCommandInputModel : BaseCommandInputModel
    {
        public SCommandInputModel(int frequency, int duration)
        {
            Frequency = frequency;
            Duration = duration;
        }
        public override int Frequency { get; set; }
        public override int Duration { get; set; }
    }

}
