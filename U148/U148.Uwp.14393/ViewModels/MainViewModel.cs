using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace U148.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _refreshCommand;

        public MainViewModel()
        {
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand(() =>
                {
                    throw new NotImplementedException();
                });
                return _refreshCommand;
            }
        }
    }
}