using System.Windows;
using BingoWallpaper.Animation;
using BingoWallpaper.Extensions;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.ViewModels;

namespace BingoWallpaper.Wpf.Views
{
    public partial class DetailView
    {
        public DetailView(Wallpaper wallpaper)
        {
            InitializeComponent();

            ViewModel.Wallpaper = wallpaper;
        }

        public IDetailViewModel ViewModel => (IDetailViewModel)DataContext;

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO

            this.GetFirstAncestorOfType<AppShell>().DetailHost.Content = null;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectedAnimationService.GetForCurrentView().GetAnimation("Wallpaper").TryStart((UIElement)sender);
        }
    }
}