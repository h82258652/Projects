using System;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class AblumDetailViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly IImageLoader _imageLoader;

        private readonly IVGtimeFileService _vgtimeFileService;

        private GameAlbum[] _gameAlbums;

        private bool _isBusy;

        private RelayCommand<GameAlbum> _saveCommand;

        private int _selectedIndex = -1;

        public AblumDetailViewModel(IImageLoader imageLoader, IAppToastService appToastService, IVGtimeFileService vgtimeFileService)
        {
            _imageLoader = imageLoader;
            _appToastService = appToastService;
            _vgtimeFileService = vgtimeFileService;
        }

        public GameAlbum[] GameAlbums
        {
            get
            {
                return _gameAlbums;
            }
            private set
            {
                Set(ref _gameAlbums, value);
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            private set
            {
                Set(ref _isBusy, value);
            }
        }

        public RelayCommand<GameAlbum> SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new RelayCommand<GameAlbum>(async gameAlbum =>
                {
                    if (IsBusy)
                    {
                        return;
                    }

                    IsBusy = true;
                    try
                    {
                        var url = gameAlbum.Url;
                        var bytes = await _imageLoader.GetBytesAsync(url);
                        var result = await _vgtimeFileService.SaveFileAsync(bytes, Path.GetFileName(url));
                        if (result)
                        {
                            _appToastService.ShowMessage("保存成功");
                        }
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                });
                return _saveCommand;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                Set(ref _selectedIndex, value);
            }
        }

        public void Activate(object parameter)
        {
            var viewParameter = (AblumDetailViewParameter)parameter;
            GameAlbums = viewParameter.GameAlbums;
            SelectedIndex = viewParameter.Index;
        }

        public void Deactivate(object parameter)
        {
        }
    }
}