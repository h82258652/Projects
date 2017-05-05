using Autofac;
using Autofac.Extras.CommonServiceLocator;
using BingoWallpaper.Configuration;
using BingoWallpaper.Services;
using BingoWallpaper.Uwp.Services;
using BingoWallpaper.Uwp.Views;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.Controls;
using SoftwareKobo.Services;
using SoftwareKobo.Support;

namespace BingoWallpaper.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string AboutViewKey = "About";

        public const string DetailViewKey = "Detail";

        public const string MainViewKey = "Main";

        public const string SettingViewKey = "Setting";

        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public DetailViewModel Detail => ServiceLocator.Current.GetInstance<DetailViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();

        public static void Cleanup()
        {
            Messenger.Reset();
        }

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());
            containerBuilder.RegisterType<LeanCloudWallpaperServiceWithCache>().As<IWallpaperService>().As<ILeanCloudWallpaperService>().As<ILeanCloudWallpaperServiceWithCache>();
            containerBuilder.RegisterType<ScreenService>().As<IScreenService>();
            containerBuilder.RegisterType<SystemSettingService>().As<ISystemSettingService>();
            containerBuilder.RegisterType<BingoFileService>().As<IBingoFileService>();
            containerBuilder.RegisterType<AppToastService>().As<IAppToastService>();
            containerBuilder.RegisterType<BingoShareService>().As<IBingoShareService>();
            containerBuilder.RegisterType<StoreService>().As<IStoreService>();
            containerBuilder.RegisterType<LauncherService>().As<ILauncherService>();

            containerBuilder.RegisterType<BingoWallpaperSettings>().As<IBingoWallpaperSettings>();

            containerBuilder.RegisterInstance(DefaultImageLoader.Instance);

            containerBuilder.RegisterType<MainViewModel>().SingleInstance();
            containerBuilder.RegisterType<DetailViewModel>();
            containerBuilder.RegisterType<SettingViewModel>();
            containerBuilder.RegisterType<AboutViewModel>();

            return containerBuilder.Build();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new SoftwareKobo.Services.NavigationService();
            navigationService.Configure(MainViewKey, typeof(MainView));
            navigationService.Configure(DetailViewKey, typeof(DetailView));
            navigationService.Configure(SettingViewKey, typeof(SettingView));
            navigationService.Configure(AboutViewKey, typeof(AboutView));
            return navigationService;
        }
    }
}