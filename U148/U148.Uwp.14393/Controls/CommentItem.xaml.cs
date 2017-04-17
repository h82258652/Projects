using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using U148.Models;
using WinRTXamlToolkit.AwaitableUI;

namespace U148.Uwp.Controls
{
    public sealed partial class CommentItem
    {
        public CommentItem()
        {
            InitializeComponent();
        }

        private async void CommentItem_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var comment = (Comment)args.NewValue;
            if (comment != null)
            {
                var contents = comment.Contents;
                await ContentHost.NavigateAsync(new Uri("ms-appx-web:///Assets/Html/comment.html"));
                await ContentHost.InvokeScriptAsync("setContent", new[]
                {
                    contents
                });
            }
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
    }
}