using System;
using System.Diagnostics;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using VGtime.Uwp.Controls;
using VGtime.Uwp.Messages;
using VGtime.Uwp.ViewModels;
using VGtime.Uwp.ViewParameters;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Navigation;
using VGtime.Models.Article;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views
{
    public sealed partial class ArticleDetailView
    {
        public ArticleDetailView()
        {
            InitializeComponent();

            ConfigureVGtimePagerAnimation();
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
                var json = JsonConvert.SerializeObject(message.ArticleDetail);
                var articleDetail = JsonConvert.DeserializeObject<ArticleDetail>(json);// 用 json 作深克隆
                var articleDetailContent = articleDetail.Content;
                articleDetailContent = articleDetailContent.Replace("src=\"//", "src=\"http://")
                                                           .Replace("src='//",  "src='http://");// 临时解决方案，下个版本得用 BuildLocalStreamUri 来解决
                articleDetail.Content = articleDetailContent;
                json = JsonConvert.SerializeObject(articleDetail);
                await WebView.InvokeScriptAsync("setArticleDetail", new[]
                {
                    json, message.Page.ToString()
                });
            });
            Messenger.Default.Register<SinaWeiboShareSelectedMessage>(this, message =>
            {
                ViewModel.SinaWeiboShareCommand.Execute(null);
            });
            Messenger.Default.Register<SystemShareSelectedMessage>(this, message =>
            {
                ViewModel.SystemShareCommand.Execute(null);
            });

            var parameter = (ArticleDetailViewParameter)e.Parameter;
            Debug.Assert(parameter != null);
            if (ViewModel.PostId != parameter.PostId)
            {
                await WebView.NavigateAsync(new Uri("about:blank"));
                ViewModel.LoadArticleDetail(parameter.PostId, parameter.DetailType);
            }
        }

        private void ConfigureVGtimePagerAnimation()
        {
            if (ApiInformation.IsMethodPresent("Windows.UI.Xaml.Hosting.ElementCompositionPreview", nameof(ElementCompositionPreview.GetElementVisual)))
            {
                var compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

                var showAnimation = compositor.CreateScalarKeyFrameAnimation();
                showAnimation.InsertKeyFrame(0f, 0);
                showAnimation.InsertKeyFrame(1f, 1);
                showAnimation.Duration = TimeSpan.FromSeconds(0.3);
                showAnimation.Target = nameof(Visual.Opacity);

                var hideAnimation = compositor.CreateScalarKeyFrameAnimation();
                hideAnimation.InsertKeyFrame(0f, 1);
                hideAnimation.InsertKeyFrame(1f, 0);
                hideAnimation.Duration = TimeSpan.FromSeconds(0.3);
                hideAnimation.Target = nameof(Visual.Opacity);

                ElementCompositionPreview.SetImplicitShowAnimation(VGtimePager, showAnimation);
                ElementCompositionPreview.SetImplicitHideAnimation(VGtimePager, hideAnimation);
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

        private void VGtimePager_PageChanged(object sender, VGtimePagerPageChangedEventArgs args)
        {
            ViewModel.LoadPage(args.NewPage);
        }

        private async void ViewInBrowserButton_Click(object sender, RoutedEventArgs e)
        {
            var articleUrl = ViewModel.ArticleDetail?.ShareUrl;
            if (!string.IsNullOrEmpty(articleUrl))
            {
                await Launcher.LaunchUriAsync(new Uri(articleUrl));
            }
        }

        private void WebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            var query = new WwwFormUrlDecoder(e.Value);
            try
            {
                var action = query.GetFirstValueByName("action");
                if (action.Equals("showUserDetail", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("followAuthor", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("showRelationGame", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(query.GetFirstValueByName("gameId"), out int gameId))
                    {
                        ViewModel.ShowRelationGameCommand.Execute(gameId);
                    }
                }
                else if (action.Equals("showCommentDetail", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("showUserDetail", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("showCommentEditor", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("commentPraise", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("showCommentList", StringComparison.OrdinalIgnoreCase))
                {
                    ViewModel.ShowCommentListCommand.Execute(null);
                }
                else if (action.Equals("showVote", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("showAlbum", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("switchPage", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("showProgramList", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO
                }
                else if (action.Equals("showNews", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(query.GetFirstValueByName("newsPostId"), out int newsPostId) && int.TryParse(query.GetFirstValueByName("newsDetailType"), out int newsDetailType))
                    {
                        ViewModel.ShowNewsCommand.Execute((newsPostId, newsDetailType));
                    }
                }
                //if (action.Equals("relatedGame", StringComparison.OrdinalIgnoreCase))
                //{
                //    if (int.TryParse(query.GetFirstValueByName("gameId"), out int gameId))
                //    {
                //        ViewModel.ShowRelationGameCommand.Execute(gameId);
                //    }
                //}
                //else if (action.Equals("relatedNews", StringComparison.OrdinalIgnoreCase))
                //{
                //    if (int.TryParse(query.GetFirstValueByName("postId"), out int postId)
                //        && int.TryParse(query.GetFirstValueByName("detailType"), out int detailType))
                //    {
                //        ViewModel.RelatedNewsCommand.Execute((postId, detailType));
                //    }
                //}
                //else if (action.Equals("moreComment", StringComparison.OrdinalIgnoreCase))
                //{
                //    ViewModel.ShowCommentListCommand.Execute(null);
                //}
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
                else if (action.Equals("scrollDown", StringComparison.OrdinalIgnoreCase))
                {
                    VGtimePager.Visibility = Visibility.Collapsed;
                }
                else if (action.Equals("scrollUp", StringComparison.OrdinalIgnoreCase))
                {
                    VGtimePager.Visibility = Visibility.Visible;
                }
            }
            catch (ArgumentException)
            {
            }
        }
    }
}