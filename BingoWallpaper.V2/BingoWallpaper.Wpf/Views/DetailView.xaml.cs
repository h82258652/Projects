using BingoWallpaper.ViewModels;

namespace BingoWallpaper.Wpf.Views
{
    public partial class DetailView
    {
        public DetailView()
        {
            InitializeComponent();
        }

        public IDetailViewModel ViewModel => (IDetailViewModel)DataContext;
    }
}