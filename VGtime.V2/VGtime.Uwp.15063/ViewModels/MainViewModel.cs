using System;
using GalaSoft.MvvmLight;
using VGtime.Models.Timeline;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IHomeService _homeService;

        private TimeLineBase[] _headpics;

        public MainViewModel(IHomeService homeService)
        {
            _homeService = homeService;

            Initialize();
        }

        public TimeLineBase[] Headpics
        {
            get
            {
                return _headpics;
            }
            private set
            {
                Set(ref _headpics, value);
            }
        }

        private async void Initialize()
        {
            try
            {
                var result = await _homeService.GetHeadpicAsync();
                if (result.Retcode == Constants.SuccessCode)
                {
                    Headpics = result.Data.Data;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
    }
}