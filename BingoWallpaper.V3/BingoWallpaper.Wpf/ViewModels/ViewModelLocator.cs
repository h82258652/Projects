using Autofac;
using Autofac.Extras.CommonServiceLocator;
using BingoWallpaper.Services;
using BingoWallpaper.ViewModels;
using BingoWallpaper.Wpf.Views;
using CommonServiceLocator;

namespace BingoWallpaper.Wpf.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        static ViewModelLocator()
        {
            var autofacServiceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);
        }

        public IDetailViewModel Detail => ServiceLocator.Current.GetInstance<IDetailViewModel>();

        public override IMainViewModel Main => ServiceLocator.Current.GetInstance<IMainViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());
            containerBuilder.RegisterType<LeanCloudService>().As<ILeanCloudService>();
            containerBuilder.RegisterType<BingoWallpaperFileService>().As<IBingoWallpaperFileService>();

            containerBuilder.RegisterType<MainViewModel>().As<IMainViewModel>();
            containerBuilder.RegisterType<DetailViewModel>().As<IDetailViewModel>();

            return containerBuilder.Build();
        }

        private static IAppNavigationService CreateNavigationService()
        {
            var appNavigationService = new AppNavigationService();

            appNavigationService.Configure(DetailViewKey, typeof(DetailView));

            return appNavigationService;
        }
    }
}