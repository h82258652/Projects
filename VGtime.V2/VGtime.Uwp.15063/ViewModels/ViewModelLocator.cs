using Microsoft.Practices.ServiceLocation;
using VGtime.Uwp.ViewModels.Games;
using VGtime.Uwp.ViewModels.Settings;
using VGtime.Uwp.ViewModels.Users;

namespace VGtime.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public ArticleDetailViewModel ArticleDetail => ServiceLocator.Current.GetInstance<ArticleDetailViewModel>();

        public GameDetailViewModel GameDetail => ServiceLocator.Current.GetInstance<GameDetailViewModel>();

        public GamePhotoViewModel GamePhoto => ServiceLocator.Current.GetInstance<GamePhotoViewModel>();

        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();
    }
}