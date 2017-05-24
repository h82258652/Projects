using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Uwp.Messages;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views
{
    public sealed partial class ArticleDetailView
    {
        public ArticleDetailView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Messenger.Default.Unregister(this);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Messenger.Default.Register<ArticleDetailLoadedMessage>(this, async message =>
            {
                await WebView.NavigateAsync(new Uri("ms-appx-web:///Assets/Html/article_detail.html"));
            });
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