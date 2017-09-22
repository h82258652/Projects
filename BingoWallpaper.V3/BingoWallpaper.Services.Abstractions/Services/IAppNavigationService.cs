namespace BingoWallpaper.Services
{
    public interface IAppNavigationService
    {
        void GoBack();

        void NavigateTo(string pageKey, object parameter);

        void NavigateTo(string pageKey);
    }
}