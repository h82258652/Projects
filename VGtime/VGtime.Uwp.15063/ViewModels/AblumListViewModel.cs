using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class AblumListViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private RelayCommand<GameAlbum> _gameAblumClickCommand;

        private GameAlbum[] _gameAlbums;

        private GameBase _game;

        private bool _isLoading;

        public AblumListViewModel(IPostService postService, IAppToastService appToastService, INavigationService navigationService)
        {
            _postService = postService;
            _appToastService = appToastService;
            _navigationService = navigationService;
        }

        public RelayCommand<GameAlbum> GameAlbumClickCommand
        {
            get
            {
                _gameAblumClickCommand = _gameAblumClickCommand ?? new RelayCommand<GameAlbum>(gameAlbum =>
                {
                    var gameAlbums = GameAlbums;
                    if (gameAlbums != null)
                    {
                        var index = Array.IndexOf(gameAlbums, gameAlbum);
                        _navigationService.NavigateTo(ViewModelLocator.AblumDetailViewKey, new AblumDetailViewParameter(gameAlbums, index));
                    }
                });
                return _gameAblumClickCommand;
            }
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

        public GameBase Game
        {
            get
            {
                return _game;
            }
            private set
            {
                Set(ref _game, value);
            }
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

        public void Activate(object parameter)
        {
            var game = (GameBase)parameter;
            if (Game == null || Game.GameId != game.GameId)
            {
                Game = game;
                GameAlbums = null;

                LoadGameAlbums();
            }
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadGameAlbums()
        {
            if (IsLoading || Game == null)
            {
                return;
            }

            IsLoading = true;
            try
            {
                var result = await _postService.GetGameAblumListAsync(Game.GameId);
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    GameAlbums = result.Data.Data;
                }
                else
                {
                    _appToastService.ShowError(result.ErrorMessage);
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