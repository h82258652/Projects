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
    }
}