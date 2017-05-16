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

        private RelayCommand<Ablum> _ablumClickCommand;

        private Ablum[] _ablums;

        private Game _game;

        private bool _isLoading;

        public AblumListViewModel(IPostService postService, IAppToastService appToastService, INavigationService navigationService)
        {
            _postService = postService;
            _appToastService = appToastService;
            _navigationService = navigationService;
        }

        public RelayCommand<Ablum> AblumClickCommand
        {
            get
            {
                _ablumClickCommand = _ablumClickCommand ?? new RelayCommand<Ablum>(ablum =>
                {
                    var ablums = Ablums;
                    var index = Array.IndexOf(ablums, ablum);
                    _navigationService.NavigateTo(ViewModelLocator.AblumDetailViewKey, new AblumDetailViewParameter(ablums, index));
                });
                return _ablumClickCommand;
            }
        }

        public Ablum[] Ablums
        {
            get
            {
                return _ablums;
            }
            private set
            {
                Set(ref _ablums, value);
            }
        }

        public Game Game
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
            Game = (Game)parameter;

            LoadGameAblums();
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadGameAblums()
        {
            IsLoading = true;
            try
            {
                var result = await _postService.GetGameAblumListAsync(Game.GameId);
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    Ablums = result.Data.Data;
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