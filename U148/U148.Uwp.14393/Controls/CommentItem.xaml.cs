using System;
using U148.Models;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Practices.ServiceLocation;
using U148.Uwp.AppThemes;
using WinRTXamlToolkit.AwaitableUI;

namespace U148.Uwp.Controls
{
    public sealed partial class CommentItem
    {
        public static readonly DependencyProperty IsReplyEnabledProperty = DependencyProperty.Register(nameof(IsReplyEnabled), typeof(bool), typeof(CommentItem), new PropertyMetadata(default(bool), OnIsReplyEnabledChanged));

        private readonly IThemeModeManager _themeModeManager;

        public CommentItem()
        {
            _themeModeManager = ServiceLocator.Current.GetInstance<IThemeModeManager>();

            InitializeComponent();
        }

        public event CommentItemReplyEventHandler Reply;

        public Comment Comment => (Comment)DataContext;

        public bool IsReplyEnabled
        {
            get
            {
                return (bool)GetValue(IsReplyEnabledProperty);
            }
            set
            {
                SetValue(IsReplyEnabledProperty, value);
            }
        }

        public void ClearReplyContent()
        {
            ReplyTextBox.Text = string.Empty;
            ReplyToggleButton.IsChecked = false;
        }

        private static void OnIsReplyEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (CommentItem)d;
            var value = (bool)e.NewValue;

            if (!value)
            {
                obj.ReplyToggleButton.IsChecked = false;
            }
        }

        private async void CommentItem_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var comment = (Comment)args.NewValue;
            if (comment != null)
            {
                var contents = comment.Contents;
                await ContentHost.NavigateAsync(new Uri("ms-appx-web:///Assets/Html/comment.html"));
                await ContentHost.InvokeScriptAsync("setThemeMode", new[]
                {
                    _themeModeManager.CurrentTheme.ToString()
                });
                await ContentHost.InvokeScriptAsync("setContent", new[]
                {
                    contents
                });
            }
        }

        private void CommentItem_Loaded(object sender, RoutedEventArgs e)
        {
            ThemeModeManager.CurrentThemeChanged += ThemeModeManager_CurrentThemeChanged;
        }

        private void CommentItem_Unloaded(object sender, RoutedEventArgs e)
        {
            ThemeModeManager.CurrentThemeChanged -= ThemeModeManager_CurrentThemeChanged;
        }

        private void ContentHost_ScriptNotify(object sender, NotifyEventArgs e)
        {
            var query = new WwwFormUrlDecoder(e.Value);
            try
            {
                var action = query.GetFirstValueByName("action");
                if (action.Equals("heightChanged", StringComparison.OrdinalIgnoreCase))
                {
                    if (long.TryParse(query.GetFirstValueByName("height"), out long height))
                    {
                        ContentHost.Height = height;
                    }
                }
            }
            catch (ArgumentException)
            {
            }
        }

        private void ReplyButton_Click(object sender, RoutedEventArgs e)
        {
            var replyContent = ReplyTextBox.Text;
            if (!string.IsNullOrEmpty(replyContent))
            {
                Reply?.Invoke(this, new CommentItemReplyEventArgs(Comment, replyContent));
            }
        }

        private async void ThemeModeManager_CurrentThemeChanged(object sender, CurrentThemeChangedEventArgs e)
        {
            try
            {
                await ContentHost.InvokeScriptAsync("setThemeMode", new[]
                {
                    e.CurrentTheme.ToString()
                });
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}