using System.Windows.Input;
using BingoWallpaper.Services;
using GalaSoft.MvvmLight.CommandWpf;

namespace BingoWallpaper.ViewModels
{
    public class DetailViewModel : IDetailViewModel
    {
        private readonly IBingoWallpaperFileService _bingoWallpaperFileService;

        private ICommand _saveCommand;

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
    }
}