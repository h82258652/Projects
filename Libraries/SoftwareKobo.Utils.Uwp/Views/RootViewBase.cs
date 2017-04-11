using Windows.UI.Xaml.Controls;

namespace SoftwareKobo.Views
{
    public abstract class RootViewBase : UserControl, IRootView
    {
        public abstract ContentControl PreviousPageHost
        {
            get;
        }

        public abstract Frame RootFrame
        {
            get;
        }
    }
}