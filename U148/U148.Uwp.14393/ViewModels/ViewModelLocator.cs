using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using U148.Configuration;
using U148.Services;
using U148.Uwp.Services;

namespace U148.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string AboutViewKey = "About";

        public const string CommentViewKey = "Comment";

        public const string DetailViewKey = "Detail";

        public const string LoginViewKey = "Login";

        public const string MainViewKey = "Main";

        public const string SettingViewKey = "Setting";

        static ViewModelLocator()
        {
            var serviceLocator = new UnityServiceLocator(ConfigureUnityContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public CommentViewModel Comment => ServiceLocator.Current.GetInstance<CommentViewModel>();

        public DetailViewModel Detail => ServiceLocator.Current.GetInstance<DetailViewModel>();

        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();

        private static IUnityContainer ConfigureUnityContainer()
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterInstance(CreateNavigationService());
            unityContainer.RegisterType<IArticleService, ArticleService>();
            unityContainer.RegisterType<ICommentService, CommentService>();
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IU148Settings, U148UwpSettings>();
            unityContainer.RegisterType<IAppToastService, AppToastService>();

            unityContainer.RegisterType<MainViewModel>();
            unityContainer.RegisterType<DetailViewModel>();
            unityContainer.RegisterType<CommentViewModel>();
            unityContainer.RegisterType<SettingViewModel>();
            unityContainer.RegisterType<LoginViewModel>();
            unityContainer.RegisterType<AboutViewModel>();

            return unityContainer;
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            // TODO
            return navigationService;
        }
    }
}