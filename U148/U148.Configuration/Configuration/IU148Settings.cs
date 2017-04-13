using U148.Models;

namespace U148.Configuration
{
    public interface IU148Settings
    {
        SimulateDevice SimulateDevice
        {
            get;
            set;
        }

        UserInfo UserInfo
        {
            get;
            set;
        }
    }
}