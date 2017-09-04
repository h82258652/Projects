using Autofac;
using Autofac.Extras.CommonServiceLocator;
using BingoWallpaper.Configuration;
using BingoWallpaper.Services;
using BingoWallpaper.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace BingoWallpaper.Wpf.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var autofacServiceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);
        }

        public IAboutViewModel About => ServiceLocator.Current.GetInstance<IAboutViewModel>();

        public IDetailViewModel Detail => ServiceLocator.Current.GetInstance<IDetailViewModel>();

        public IMainViewModel Main => ServiceLocator.Current.GetInstance<IMainViewModel>();

        public ISettingViewModel Setting => ServiceLocator.Current.GetInstance<ISettingViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<BingoWallpaperSettings>().As<IBingoWallpaperSettings>();

            containerBuilder.RegisterType<LeanCloudService>().As<ILeanCloudService>();

            containerBuilder.RegisterType<MainViewModel>().As<IMainViewModel>();
            containerBuilder.RegisterType<DetailViewModel>().As<IDetailViewModel>();
            containerBuilder.RegisterType<SettingViewModel>().As<ISettingViewModel>();
            containerBuilder.RegisterType<AboutViewModel>().As<IAboutViewModel>();

            return containerBuilder.Build();
        }
    }
}