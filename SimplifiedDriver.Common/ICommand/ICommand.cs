using SimplifiedDriver.Common.Models;

namespace SimplifiedDriver.Common.ICommand
{
    public interface ICommand
    {
        void Execute(BaseCommandInputModel data);
    }
}
