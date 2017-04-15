using System.Diagnostics;
using U148.Models;

namespace U148.Uwp.Controls
{
    public sealed partial class ArticleItem
    {
        public ArticleItem()
        {
            InitializeComponent();

            this.DataContextChanged += ArticleItem_DataContextChanged;
        }

        private void ArticleItem_DataContextChanged(Windows.UI.Xaml.FrameworkElement sender, Windows.UI.Xaml.DataContextChangedEventArgs args)
        {
            var article = args.NewValue as Article;
            var p = article?.PicMid;
            if (string.IsNullOrEmpty(p))
            {
            }
        }
    }
}