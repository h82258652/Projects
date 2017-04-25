using System;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Uwp.Messages;
using Windows.UI.Xaml.Navigation;

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Messenger.Default.Register<PostContentLoadedMessage>(this, async message =>
            {
                await WebView.InvokeScriptAsync("setContent", new[]
                {
                    message.Content
                });
            });
        }
    }
}