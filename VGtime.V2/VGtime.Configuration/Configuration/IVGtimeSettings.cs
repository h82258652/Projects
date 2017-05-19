using VGtime.Models.Users;

namespace VGtime.Configuration
{
    public interface IVGtimeSettings
    {
        string StartPicture
        {
            get;
            set;
        }

        UserBase UserInfo
        {
            get;
            set;
        }
    }
}