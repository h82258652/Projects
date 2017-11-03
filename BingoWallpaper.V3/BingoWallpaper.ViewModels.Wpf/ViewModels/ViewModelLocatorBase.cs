namespace BingoWallpaper.ViewModels
{
    public abstract class ViewModelLocatorBase
    {
        public const string DetailViewKey = "Detail";

        public abstract IMainViewModel Main
        {
            get;
        }

        public abstract IDetailViewModel Detail
        {
            get;
        }

        public abstract ISettingViewModel Setting
        {
            get;
        }
    }
}