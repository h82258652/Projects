using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace BingoWallpaper.ViewModels
{
    public class DetailViewModel : ViewModelBase, IDetailViewModel
    {
        private readonly IBingoWallpaperFileService _bingoWallpaperFileService;

        private ICommand _saveCommand;

        private Wallpaper _wallpaper;

        public DetailViewModel(IBingoWallpaperFileService bingoWallpaperFileService)
        {
            _bingoWallpaperFileService = bingoWallpaperFileService;
        }

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new RelayCommand(() =>
                {
                    // TODO
                });
                return _saveCommand;
            }
        }

        public Wallpaper Wallpaper
        {
            get
            {
                return _wallpaper;
            }
            set
            {
                Set(ref _wallpaper, value);
            }
        }
    }
}