using Windows.ApplicationModel.Resources;

namespace BingoWallpaper
{
    internal static class LocalizedStrings
    {
        internal static string EmptyStringExceptionMessage => ResourceLoader.GetForCurrentView("BingoWallpaper.Services.Uwp.10586/Resources").GetString("EmptyStringExceptionMessage");
    }
}