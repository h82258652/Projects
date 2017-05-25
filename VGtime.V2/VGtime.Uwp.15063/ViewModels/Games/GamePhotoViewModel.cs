using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GamePhotoViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private readonly INavigationService _navigationService;

        private bool _isLoading;

        private RelayCommand<GameAlbum> _photoClickCommand;

        private GameAlbum[] _photos;

        public GamePhotoViewModel(IGameService gameService, IAppToastService appToastService, INavigationService navigationService)
        {
            _gameService = gameService;
            _appToastService = appToastService;
            _navigationService = navigationService;
        }

        public int GameId
        {
            get;
            private set;
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            private set
            {
                Set(ref _isLoading, value);
            }
        }

        public RelayCommand<GameAlbum> PhotoClickCommand
        {
            get
            {
                _photoClickCommand = _photoClickCommand ?? new RelayCommand<GameAlbum>(photo =>
                {
                    if (photo == null)
                    {
                        return;
                    }
                    var photos = Photos;
                    if (photos == null)
                    {
                        return;
                    }
                    var index = Array.IndexOf(photos, photo);
                    if (index >= 0)
                    {
                        _navigationService.NavigateTo(ViewModelLocator.ImagePagerViewKey, new ImagePagerViewParameter(photos, index));
                    }
                });
                return _photoClickCommand;
            }
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

        public void LoadPhotos(int gameId)
        {
            GameId = gameId;
            LoadPhotos();
        }

        private async void LoadPhotos()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;

                var result = await _gameService.GetAlbumListAsync(GameId);
                if (result.Retcode == Constants.SuccessCode)
                {
                    Photos = result.Data.Data;
                }
                else
                {
                    _appToastService.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                _appToastService.ShowError(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}