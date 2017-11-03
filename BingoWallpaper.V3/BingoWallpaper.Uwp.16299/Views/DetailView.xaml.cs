using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.ViewModels;

namespace BingoWallpaper.Uwp.Views
{
    public sealed partial class DetailView
    {
        public IDetailViewModel ViewModel => (IDetailViewModel)DataContext;

        public DetailView(Wallpaper wallpaper)
        {
            InitializeComponent();

            ViewModel.Wallpaper = wallpaper;
        }
    }
}