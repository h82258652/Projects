using System;
using System.Diagnostics;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Uwp.Messages;
using VGtime.Uwp.ViewParameters;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using VGtime.Uwp.ViewModels;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views
{
    public sealed partial class ArticleDetailView
    {
        public ArticleDetailView()
        {
            InitializeComponent();
        }

        public ArticleDetailViewModel ViewModel => (ArticleDetailViewModel)DataContext;

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Messenger.Default.Unregister(this);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Messenger.Default.Register<ArticleDetailLoadedMessage>(this, async message =>
            {
                await WebView.NavigateAsync(new Uri("ms-appx-web:///Assets/Html/article_detail.html"));
                await WebView.InvokeScriptAsync("setArticleDetail", new[]
                {
                    JsonConvert.SerializeObject(message.ArticleDetail)
                });
            });

            var parameter = (ArticleDetailViewParameter)e.Parameter;
            Debug.Assert(parameter != null);
            if (ViewModel.PostId != parameter.PostId)
            {
                await WebView.NavigateAsync(new Uri("about:blank"));
                ViewModel.LoadArticleDetail(parameter.PostId, parameter.DetailType);
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
                if (action.Equals("relatedGame", StringComparison.OrdinalIgnoreCase))
                {
                    int gameId;
                    if (int.TryParse(query.GetFirstValueByName("gameId"), out gameId))
                    {
                        ViewModel.RelatedGameCommand.Execute(gameId);
                    }
                }
                else if (action.Equals("moreComment", StringComparison.OrdinalIgnoreCase))
                {
                    ViewModel.MoreCommentCommand.Execute(null);
                }
                else if (action.Equals("goBack", StringComparison.OrdinalIgnoreCase))
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