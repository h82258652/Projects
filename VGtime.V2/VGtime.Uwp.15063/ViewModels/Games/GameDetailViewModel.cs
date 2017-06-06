using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.Controls;
using SoftwareKobo.Social.SinaWeibo;
using VGtime.Configuration;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Messages;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GameDetailViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private readonly IImageLoader _imageLoader;

        private readonly INavigationService _navigationService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private readonly IVGtimeShareService _vgtimeShareService;

        private RelayCommand _forumCommand;

        private GameBase _gameDetail;

        private int _gameId;

        private bool _isLoading;

        private RelayCommand _photoCommand;

        private RelayCommand _postCommand;

        private RelayCommand _questionCommand;

        private RelayCommand _scoreCommand;

        private RelayCommand _shareCommand;

        private RelayCommand _sinaWeiboShareCommand;

        private RelayCommand _strategyCommand;

        private RelayCommand _systemShareCommand;

        public GameDetailViewModel(IGameService gameService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService, INavigationService navigationService, IImageLoader imageLoader, IVGtimeShareService vgtimeShareService)
        {
            _gameService = gameService;
            _vgtimeSettings = vgtimeSettings;
            _appToastService = appToastService;
            _navigationService = navigationService;
            _vgtimeShareService = vgtimeShareService;
            _imageLoader = imageLoader;
        }

        public RelayCommand ForumCommand
        {
            get
            {
                _forumCommand = _forumCommand ?? new RelayCommand(() =>
                {
                    // TODO in next version.
                    //_navigationService.NavigateTo(ViewModelLocator.GameRelationViewKey, new GameRelationViewParameter(GameId, 1));
                });
                return _forumCommand;
            }
        }

        public GameBase GameDetail
        {
            get
            {
                return _gameDetail;
            }
            private set
            {
                Set(ref _gameDetail, value);
            }
        }

        public int GameId
        {
            get
            {
                return _gameId;
            }
            private set
            {
                if (_gameId != value)
                {
                    _gameId = value;
                    GameDetail = null;
                }
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

        public RelayCommand PhotoCommand
        {
            get
            {
                _photoCommand = _photoCommand ?? new RelayCommand(() =>
                {
                    if (GameDetail != null)
                    {
                        if (GameDetail.ImageCount <= 0)
                        {
                            _appToastService.ShowInformation("没有相应的游戏图集哦");
                        }
                        else
                        {
                            _navigationService.NavigateTo(ViewModelLocator.GamePhotoViewKey, new GamePhotoViewParameter(GameId, GameDetail.Title));
                        }
                    }
                });
                return _photoCommand;
            }
        }

        public RelayCommand PostCommand
        {
            get
            {
                _postCommand = _postCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GamePostViewKey, GameId);
                });
                return _postCommand;
            }
        }

        public RelayCommand QuestionCommand
        {
            get
            {
                _questionCommand = _questionCommand ?? new RelayCommand(() =>
                {
                    // TODO in next version.
                    //_navigationService.NavigateTo(ViewModelLocator.GameRelationViewKey, new GameRelationViewParameter(GameId, 3));
                });
                return _questionCommand;
            }
        }

        public RelayCommand ScoreCommand
        {
            get
            {
                _scoreCommand = _scoreCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameScoreViewKey, GameId);
                });
                return _scoreCommand;
            }
        }

        public RelayCommand ShareCommand
        {
            get
            {
                _shareCommand = _shareCommand ?? new RelayCommand(() =>
                {
                    MessengerInstance.Send(new ShowChooseShareDialogMessage());
                });
                return _shareCommand;
            }
        }

        public RelayCommand SinaWeiboShareCommand
        {
            get
            {
                _sinaWeiboShareCommand = _sinaWeiboShareCommand ?? new RelayCommand(async () =>
                {
                    var gameDetail = GameDetail;
                    if (gameDetail == null)
                    {
                        return;
                    }

                    try
                    {
                        var imageUrl = gameDetail.Thumbnail.Url;
                        var bytes = await _imageLoader.GetBytesAsync(imageUrl);
                        var text = string.Join(Environment.NewLine, $"{gameDetail.Title} 游戏时光评分：{gameDetail.Score:F1}", gameDetail.ShareUrl);
                        var result = await _vgtimeShareService.ShareToSinaWeiboAsync(text, bytes);
                        if (result.ErrorCode <= 0)
                        {
                            _appToastService.ShowMessage(LocalizedStrings.ShareSuccess);
                        }
                        else
                        {
                            _appToastService.ShowError(result.ErrorMessage);
                        }
                    }
                    catch (UserCancelAuthorizeException)
                    {
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                });
                return _sinaWeiboShareCommand;
            }
        }

        public RelayCommand StrategyCommand
        {
            get
            {
                _strategyCommand = _strategyCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameStrategySetViewKey, GameId);
                });
                return _strategyCommand;
            }
        }

        public RelayCommand SystemShareCommand
        {
            get
            {
                _systemShareCommand = _systemShareCommand ?? new RelayCommand(async () =>
                {
                    var gameDetail = GameDetail;
                    if (gameDetail == null)
                    {
                        return;
                    }

                    var title = $"{gameDetail.Title} 游戏时光评分：{gameDetail.Score:F1}";
                    await _vgtimeShareService.ShareToSystemAsync(title, gameDetail.ShareUrl, gameDetail.Thumbnail.Url);
                });
                return _systemShareCommand;
            }
        }

        public void LoadDetail(int gameId)
        {
            GameId = gameId;
            LoadDetail();
        }

        private async void LoadDetail()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;

                var gameId = GameId;
                var result = await _gameService.GetDetailAsync(gameId, _vgtimeSettings.UserInfo?.UserId);
                if (gameId == GameId)
                {
                    if (result.Retcode == Constants.SuccessCode)
                    {
                        GameDetail = result.Data.Game;
                    }
                    else
                    {
                        _appToastService.ShowError(result.Message);
                    }
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