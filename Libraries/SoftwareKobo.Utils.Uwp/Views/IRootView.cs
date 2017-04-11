using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.Views
{
    public interface IRootView
    {
        ContentControl PreviousPageHost
        {
            get;
        }

        Frame RootFrame
        {
            get;
        }
    }
}