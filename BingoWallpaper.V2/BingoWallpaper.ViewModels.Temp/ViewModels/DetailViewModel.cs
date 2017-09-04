using System;
using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BingoWallpaper.ViewModels
{
    public class DetailViewModel : ViewModelBase, IDetailViewModel
    {
        private RelayCommand _saveCommand;

        public DetailViewModel()
        {
        }

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new RelayCommand(() =>
                {
                    throw new NotImplementedException();
                });
                return _saveCommand;
            }
        }

        public Wallpaper Wallpaper
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}