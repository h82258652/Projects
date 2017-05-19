using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using VGtime.Uwp.ViewModels.Games;
using VGtime.Uwp.ViewModels.Settings;
using VGtime.Uwp.ViewModels.Users;

namespace VGtime.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public ArticleDetailViewModel ArticleDetail => ServiceLocator.Current.GetInstance<ArticleDetailViewModel>();

        public GameDetailViewModel GameDetail => ServiceLocator.Current.GetInstance<GameDetailViewModel>();

        public GamePhotoViewModel GamePhoto => ServiceLocator.Current.GetInstance<GamePhotoViewModel>();

        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());

            containerBuilder.RegisterType<AboutViewModel>();
            containerBuilder.RegisterType<ArticleDetailViewModel>();
            containerBuilder.RegisterType<GameDetailViewModel>();
            containerBuilder.RegisterType<GamePhotoViewModel>();
            containerBuilder.RegisterType<LoginViewModel>();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<SearchViewModel>();
            containerBuilder.RegisterType<SettingViewModel>();

            return containerBuilder.Build();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            return navigationService;
        }
    }
}