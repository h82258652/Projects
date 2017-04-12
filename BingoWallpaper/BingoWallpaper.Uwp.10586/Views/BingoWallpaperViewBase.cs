using SoftwareKobo.Views;
using Windows.ApplicationModel;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace BingoWallpaper.Uwp.Views
{
    public abstract class BingoWallpaperViewBase : ViewBase
    {
        private readonly SystemNavigationManager _systemNavigationManager;

        protected BingoWallpaperViewBase()
        {
            if (DesignMode.DesignModeEnabled == false)
            {
                _systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            _systemNavigationManager.AppViewBackButtonVisibility = Frame.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
            _systemNavigationManager.BackRequested -= SystemNavigationManager_BackRequested;

            var coreWindow = Window.Current.CoreWindow;
            coreWindow.PointerReleased -= CurrentWindow_PointerReleased;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _systemNavigationManager.AppViewBackButtonVisibility = Frame.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
            _systemNavigationManager.BackRequested += SystemNavigationManager_BackRequested;

            var coreWindow = Window.Current.CoreWindow;
            coreWindow.PointerReleased += CurrentWindow_PointerReleased;
        }

        private void CurrentWindow_PointerReleased(CoreWindow sender, PointerEventArgs args)
        {
            switch (args.CurrentPoint.Properties.PointerUpdateKind)
            {
                case PointerUpdateKind.XButton1Released:
                    if (Frame.CanGoBack)
                    {
                        args.Handled = true;
                        Frame.GoBack();
                    }
                    break;

                case PointerUpdateKind.XButton2Released:
                    if (Frame.CanGoForward)
                    {
                        args.Handled = true;
                        Frame.GoForward();
                    }
                    break;
            }
        }

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }
    }
}