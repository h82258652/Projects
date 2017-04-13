using U148.Models;

namespace U148.Configuration
{
    public interface IU148UwpSettings : IU148Settings
    {
        ThemeMode ThemeMode
        {
            get;
            set;
        }
    }
}