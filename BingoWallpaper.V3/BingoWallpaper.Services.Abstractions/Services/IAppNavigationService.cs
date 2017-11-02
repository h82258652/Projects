namespace BingoWallpaper.Services
{
    public interface IAppNavigationService
    {
        void GoBack();

        void NavigateTo(string pageKey);

        void NavigateTo(string pageKey, object parameter);
    }
}