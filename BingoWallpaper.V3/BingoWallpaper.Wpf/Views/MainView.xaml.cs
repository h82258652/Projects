using System.Windows;
using System.Windows.Controls;
using BingoWallpaper.Animation;
using BingoWallpaper.Extensions;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Wpf.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            var image = ((DependencyObject)sender).GetFirstDescendantOfType<System.Windows.Controls.Image>();
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("Wallpaper", image);

            // TODO

            var detailView = new DetailView((sender as Button)?.DataContext as Wallpaper);
            var firstAncestorOfType = this.GetFirstAncestorOfType<AppShell>();
            firstAncestorOfType.DetailHost.Content = detailView;
        }
    }
}