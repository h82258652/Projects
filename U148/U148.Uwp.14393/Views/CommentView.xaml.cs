using GalaSoft.MvvmLight.Messaging;
using U148.Uwp.Controls;
using U148.Uwp.Messages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

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
        }

        private void CommentItem_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<ReplyCommentSuccessMessage>(sender, message =>
            {
                var commentItem = (CommentItem)sender;
                if (commentItem.Comment.Id == message.Comment.Id)
                {
                    commentItem.ClearReplyContent();
                }
            });
        }

        private void CommentItem_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister(sender);
        }
    }
}