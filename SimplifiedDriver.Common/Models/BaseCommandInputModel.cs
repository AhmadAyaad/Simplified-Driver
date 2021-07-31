namespace SimplifiedDriver.Common.Models
{
    public class BaseCommandInputModel
    {
        public string Message { get; set; }
        public virtual int Frequency { get; set; } = 0;
        public virtual int Duration { get; set; } = 0;
        public override string ToString()
        {
            return $"{Message}";
        }
    }
}
