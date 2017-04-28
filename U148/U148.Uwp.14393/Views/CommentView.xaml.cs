using GalaSoft.MvvmLight.Messaging;
using U148.Uwp.Controls;
using U148.Uwp.Messages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.Extensions;

namespace U148.Uwp.Views
{
    public sealed partial class CommentView
    {
        public CommentView()
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

            Messenger.Default.Register<SendCommentSuccessMessage>(this, message =>
            {
                CommentTextBox.Text = string.Empty;
            });
            Messenger.Default.Register<ReplyCommentSuccessMessage>(this, message =>
            {
                ClearReplyContent();
            });
        }

        private void ClearReplyContent()
        {
            foreach (var commentItem in CommentsListView.GetDescendantsOfType<CommentItem>())
            {
                commentItem.ClearReplyContent();
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ClearReplyContent();
        }
    }
}