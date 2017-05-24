using System;
using GalaSoft.MvvmLight;
using VGtime.Configuration;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels
{
    public class ArticleDetailViewModel : ViewModelBase
    {
        // input
        public int _page;

        // input
        public int _postId;

        // input
        public int _type;

        private readonly IAppToastService _appToastService;

        private readonly IPostService _postService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private bool _isLoading;

        public ArticleDetailViewModel(IPostService postService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService)
        {
            _postService = postService;
            _vgtimeSettings = vgtimeSettings;
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

        public async void X()
        {
            try
            {
                var result = await _postService.GetDetailAsync(_postId, _type, _vgtimeSettings.UserInfo?.UserId);
                if (result.Retcode == Constants.SuccessCode)
                {
                    var articleDetail = result.Data.Data;

                    MessengerInstance.Send(new Messages.ArticleDetailLoadedMessage(articleDetail));
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
        }
    }
}