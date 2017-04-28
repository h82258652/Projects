using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.Views;

namespace VGtime.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string CommentViewKey = "Comment";

        public const string DetailViewKey = "Detail";

        static ViewModelLocator()
        {
            var serviceLocator = new UnityServiceLocator(ConfigureUnityContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public CommentViewModel Comment => ServiceLocator.Current.GetInstance<CommentViewModel>();

        public DetailViewModel Detail => ServiceLocator.Current.GetInstance<DetailViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        private static IUnityContainer ConfigureUnityContainer()
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterInstance(CreateNavigationService());
            unityContainer.RegisterType<IPostService, PostService>();
            unityContainer.RegisterType<IAppToastService, AppToastService>();

            unityContainer.RegisterType<MainViewModel>();
            unityContainer.RegisterType<DetailViewModel>();
            unityContainer.RegisterType<CommentViewModel>();

            return unityContainer;
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure(DetailViewKey, typeof(DetailView));
            navigationService.Configure(CommentViewKey, typeof(CommentView));
            return navigationService;
        }
    }
}