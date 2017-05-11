using System;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Uwp.Messages;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views
{
    public sealed partial class DetailView
    {
        public DetailView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Messenger.Default.Unregister(this);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            Messenger.Default.Register<PostContentLoadedMessage>(this, async message =>
            {
                await WebView.NavigateAsync(new Uri("ms-appx-web:///Assets/Html/detail.html"));
                await WebView.InvokeScriptAsync("setContent", new[]
                {
                    message.Content
                });
            });

            if (e.NavigationMode == NavigationMode.New)
            {
                await WebView.NavigateAsync(new Uri("about:blank"));
                base.OnNavigatedTo(e);
            }
        }

        private async void ScrollToTopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await WebView.InvokeScriptAsync("scrollToTop", new string[]
                {
                });
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void WebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            var query = new WwwFormUrlDecoder(e.Value);
            try
            {
                var action = query.GetFirstValueByName("action");
                if (action.Equals("goBack", StringComparison.OrdinalIgnoreCase))
                {
                    if (Frame.CanGoBack)
                    {
                        Frame.GoBack();
                    }
                }
                else if (action.Equals("goForward", StringComparison.OrdinalIgnoreCase))
                {
                    if (Frame.CanGoForward)
                    {
                        Frame.GoForward();
                    }
                }
            }
            catch (ArgumentException)
            {
            }
        }
    }
}