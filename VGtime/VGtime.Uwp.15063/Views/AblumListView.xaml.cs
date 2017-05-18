using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace VGtime.Uwp.Views
{
    public sealed partial class AblumListView
    {
        internal static int NavigationBackIndex;

        public AblumListView()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                base.OnNavigatedTo(e);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("AlbumBack");
                var items = AlbumGridView.Items;
                if (animation != null && items != null)
                {
                    var item = items.ElementAtOrDefault(NavigationBackIndex);
                    if (item != null)
                    {
                        AlbumGridView.ScrollIntoView(item);
                        await AlbumGridView.TryStartConnectedAnimationAsync(animation, item, "Image");
                    }
                }
            }
        }

        private void AlbumGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = (GridView)sender;
            gridView.PrepareConnectedAnimation("Album", e.ClickedItem, "Image");
        }

        private void AlbumGridView_SizeChanged(object sender, SizeChangedEventArgs e)
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