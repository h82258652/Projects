using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Views
{
    public sealed partial class AblumListView
    {
        public AblumListView()
        {
            InitializeComponent();
        }

        private void AblumGridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var itemsControl = (ItemsControl)sender;
            var itemsWrapGrid = (ItemsWrapGrid)itemsControl.ItemsPanelRoot;
            Debug.Assert(itemsWrapGrid != null);
            var width = e.NewSize.Width - itemsControl.Padding.Left;
            var column = Math.Ceiling(width / 480);
            itemsWrapGrid.ItemWidth = width / column;
        }
    }
}