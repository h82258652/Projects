using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using U148.Uwp.Messages;

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
    }
}