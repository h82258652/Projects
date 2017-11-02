using Autofac;
using Autofac.Extras.CommonServiceLocator;
using BingoWallpaper.Services;
using BingoWallpaper.ViewModels;
using CommonServiceLocator;

namespace BingoWallpaper.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var autofacServiceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);
        }

        public IMainViewModel Main => ServiceLocator.Current.GetInstance<IMainViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<LeanCloudService>().As<ILeanCloudService>();

            //containerBuilder.RegisterType<MainViewModel>().As<IMainViewModel>();

            return containerBuilder.Build();
        }
    }
}