using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels
{
    public class AblumListViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly IPostService _postService;

        private RelayCommand<Ablum> _ablumClickCommand;

        private Ablum[] _ablums;

        private int _gameId;

        private bool _isLoading;

        public AblumListViewModel(IPostService postService, IAppToastService appToastService)
        {
            _postService = postService;
            _appToastService = appToastService;
        }

        public RelayCommand<Ablum> AblumClickCommand
        {
            get
            {
                _ablumClickCommand = _ablumClickCommand ?? new RelayCommand<Ablum>(ablum =>
                {
                    throw new NotImplementedException();
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
            _gameId = (int)parameter;

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
                var result = await _postService.GetGameAblumListAsync(_gameId);
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