using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Services;

namespace U148.Uwp.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private readonly IStoreService _storeService;

        private RelayCommand _praiseCommand;

        public AboutViewModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public RelayCommand PraiseCommand
        {
            get
            {
                _praiseCommand = _praiseCommand ?? new RelayCommand(async () =>
                {
                    await _storeService.OpenCurrentAppReviewPageAsync();
                });
                return _praiseCommand;
            }
        }
    }
}