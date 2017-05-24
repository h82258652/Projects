using GalaSoft.MvvmLight;
using SoftwareKobo.Controls;
using VGtime.Models.Games;

namespace VGtime.Uwp.ViewModels.Image
{
    public class ImagePagerViewModel : ViewModelBase
    {
        private GameAlbum[] _photos;

        private readonly IImageLoader _imageLoader;

        public ImagePagerViewModel(IImageLoader imageLoader)
        {
            _imageLoader = imageLoader;
        }

        public GameAlbum[] Photos
        {
            get
            {
                return _photos;
            }
            private set
            {
                Set(ref _photos, value);
            }
        }
    }
}