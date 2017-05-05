using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.Controls;
using SoftwareKobo.Services;
using U148.Configuration;
using U148.Services;
using U148.Uwp.Services;
using U148.Uwp.Views;

namespace U148.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string AboutViewKey = "About";

        public const string ArticleViewKey = "Article";

        public const string CommentViewKey = "Comment";

        public const string DetailViewKey = "Detail";

        public const string LoginViewKey = "Login";

        public const string MainViewKey = "Main";

        public const string RootViewKey = "Root";

        public const string SearchViewKey = "Search";

        public const string SettingViewKey = "Setting";

        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public ArticleViewModel Article => ServiceLocator.Current.GetInstance<ArticleViewModel>();

        public CommentViewModel Comment => ServiceLocator.Current.GetInstance<CommentViewModel>();

        public DetailViewModel Detail => ServiceLocator.Current.GetInstance<DetailViewModel>();

        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public RootViewModel Root => ServiceLocator.Current.GetInstance<RootViewModel>();

        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());
            containerBuilder.RegisterType<ArticleServiceWithCache>().As<IArticleService>().As<IArticleServiceWithCache>();
            containerBuilder.RegisterType<CommentService>().As<ICommentService>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<AppToastService>().As<IAppToastService>();
            containerBuilder.RegisterType<U148ShareService>().As<IU148ShareService>();
            containerBuilder.RegisterType<StoreService>().As<IStoreService>();

            containerBuilder.RegisterType<U148UwpSettings>().As<IU148Settings>().As<IU148UwpSettings>();

            containerBuilder.RegisterInstance(DefaultImageLoader.Instance);

            containerBuilder.RegisterType<RootViewModel>();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<ArticleViewModel>().SingleInstance();
            containerBuilder.RegisterType<DetailViewModel>();
            containerBuilder.RegisterType<CommentViewModel>();
            containerBuilder.RegisterType<SearchViewModel>();
            containerBuilder.RegisterType<SettingViewModel>();
            containerBuilder.RegisterType<LoginViewModel>();
            containerBuilder.RegisterType<AboutViewModel>();

            return containerBuilder.Build();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new U148NavigationService();
            navigationService.Configure(ArticleViewKey, typeof(ArticleView), U148NavigationType.Master);
            navigationService.Configure(SearchViewKey, typeof(SearchView), U148NavigationType.Master);
            navigationService.Configure(DetailViewKey, typeof(DetailView), U148NavigationType.Detail);
            navigationService.Configure(CommentViewKey, typeof(CommentView), U148NavigationType.Detail);
            navigationService.Configure(AboutViewKey, typeof(AboutView), U148NavigationType.Detail);
            navigationService.Configure(SettingViewKey, typeof(SettingView), U148NavigationType.Detail);
            return navigationService;
        }
    }
}