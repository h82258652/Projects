using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Messages;

namespace VGtime.Uwp.ViewModels
{
    public class DetailViewModel : ViewModelBase, INavigable
    {
        private readonly IDialogService _dialogService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private RelayCommand _commentCommand;

        private bool _isLoading;

        private Post _post;

        private RelayCommand _refreshCommand;

        public DetailViewModel(IPostService postService, INavigationService navigationService, IDialogService dialogService)
        {
            _postService = postService;
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        public RelayCommand CommentCommand
        {
            get
            {
                _commentCommand = _commentCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.CommentViewKey, _post);
                });
                return _commentCommand;
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                Set(ref _isLoading, value);
            }
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

        public async void Activate(object parameter)
        {
            _post = (Post)parameter;

            IsLoading = true;
            try
            {
                var result = await _postService.GetDetailAsync(_post.PostId, 0);
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    var dataData = result.Data.Data;
                    var dataDataContent = dataData.Content;

                    MessengerInstance.Send(new PostContentLoadedMessage(dataDataContent));
                }
                else
                {
                    await _dialogService.ShowError(result.ErrorMessage, string.Empty, null, null);
                }
            }
            catch (Exception ex)
            {
                await _dialogService.ShowError(ex, string.Empty, null, null);
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void Deactivate(object parameter)
        {
        }
    }
}