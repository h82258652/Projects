using System;
using GalaSoft.MvvmLight.Messaging;
using U148.Uwp.Messages;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using U148.Uwp.ViewModels;
using WinRTXamlToolkit.AwaitableUI;

namespace U148.Uwp.Views
{
    public sealed partial class DetailView
    {
        public DetailView()
        {
            InitializeComponent();
        }

        public DetailViewModel ViewModel => (DetailViewModel)DataContext;

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Messenger.Default.Unregister(this);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            Messenger.Default.Register<ArticleContentLoadedMessage>(this, async message =>
            {
                if (ViewModel.Article?.Id == message.Article.Id)
                {
                    await WebView.NavigateAsync(new Uri("ms-appx-web:///Assets/Html/article.html"));
                    await WebView.InvokeScriptAsync("setContent", new[]
                    {
                        message.Content
                    });
                }
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

        private void WebView_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            var url = args.Uri.OriginalString;
            if (url.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || url.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                || url.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                || url.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
            {
                // TODO
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