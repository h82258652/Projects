using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GamePhotoViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private int _gameId;

        private bool _isLoading;

        private RelayCommand<GameAlbum> _photoClickCommand;

        private GameAlbum[] _photos;

        public GamePhotoViewModel(IGameService gameService, IAppToastService appToastService)
        {
            _gameService = gameService;
            _appToastService = appToastService;
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
                    // TODO
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

        public async void TODO()
        {
            IsLoading = true;
            try
            {
                var result = await _gameService.GetAlbumListAsync(_gameId);
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