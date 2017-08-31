using Autofac.Extras.CommonServiceLocator;
using BingoWallpaper.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace BingoWallpaper.Wpf.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var autofacServiceLocator = new AutofacServiceLocator(null);
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);
        }

        public IAboutViewModel About => ServiceLocator.Current.GetInstance<IAboutViewModel>();

        public IDetailViewModel Detail => ServiceLocator.Current.GetInstance<IDetailViewModel>();

        public IMainViewModel Main => ServiceLocator.Current.GetInstance<IMainViewModel>();

        public ISettingViewModel Setting => ServiceLocator.Current.GetInstance<ISettingViewModel>();
    }
}