using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public MainViewModel ViewModel => (MainViewModel)DataContext;

        protected override Task PlayLeaveAnimationAsync(NavigationMode currentPageNavigationMode)
        {
            // Hack fix.
            Action asyncAction = async () =>
            {
                MainPivot.Width = MainPivot.ActualWidth + 1;
                await MainPivot.WaitForLayoutUpdateAsync();
                MainPivot.Width = double.NaN;
            };
            asyncAction();

            return base.PlayLeaveAnimationAsync(currentPageNavigationMode);
        }
    }
}