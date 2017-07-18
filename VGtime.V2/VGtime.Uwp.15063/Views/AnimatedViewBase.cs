using System;
using System.Reflection;
using System.Threading.Tasks;
using VGtime.Uwp.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views
{
    public abstract class AnimatedViewBase : ViewBase
    {
        private bool _isLeaving;

        protected AnimatedViewBase()
        {
            base.Loaded += ViewBase_Loaded;
            base.Unloaded += ViewBase_Unloaded;
        }

        public new event RoutedEventHandler Loaded;

        public new event RoutedEventHandler Unloaded;

        protected abstract ContentControl PreviousPageHost
        {
            get;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (typeof(AnimatedViewBase).GetTypeInfo().IsAssignableFrom(e.SourcePageType.GetTypeInfo()))
            {
                FrameExtensions.SetPreviousPage(Frame, this);
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var previousPage = FrameExtensions.GetPreviousPage(Frame);
            if (previousPage != null)
            {
                try
                {
                    previousPage._isLeaving = true;
                    var previousPageHost = PreviousPageHost;
                    if (previousPageHost != null)
                    {
                        try
                        {
                            previousPageHost.Content = previousPage;
                            await previousPage.WaitForLoadedAsync();
                            await previousPage.PlayLeaveAnimationAsync(e.NavigationMode);
                        }
                        catch (ArgumentException)
                        {
                        }
                        finally
                        {
                            previousPageHost.Content = null;
                        }
                    }
                }
                finally
                {
                    FrameExtensions.SetPreviousPage(Frame, null);
                    previousPage._isLeaving = false;
                }
            }
        }

        protected virtual Task PlayEnterAnimationAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task PlayLeaveAnimationAsync(NavigationMode currentPageNavigationMode)
        {
            return Task.CompletedTask;
        }

        private async void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_isLeaving)
            {
                Loaded?.Invoke(sender, e);
                await PlayEnterAnimationAsync();
            }
        }

        private void ViewBase_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!_isLeaving)
            {
                Unloaded?.Invoke(sender, e);
            }
        }
    }
}