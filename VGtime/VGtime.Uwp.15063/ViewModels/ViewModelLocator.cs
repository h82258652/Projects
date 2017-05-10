using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.Controls;
using VGtime.Configuration;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.Views;

namespace VGtime.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string CommentViewKey = "Comment";

        public const string DetailViewKey = "Detail";

        public const string SearchViewKey = "Search";

        public const string StrategyViewKey = "Strategy";

        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public CommentViewModel Comment => ServiceLocator.Current.GetInstance<CommentViewModel>();

        public DetailViewModel Detail => ServiceLocator.Current.GetInstance<DetailViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public SplashScreenViewModel SplashScreen => ServiceLocator.Current.GetInstance<SplashScreenViewModel>();

        public StrategyViewModel Strategy => ServiceLocator.Current.GetInstance<StrategyViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());
            containerBuilder.RegisterType<PostService>().As<IPostService>();
            containerBuilder.RegisterType<AppToastService>().As<IAppToastService>();

            containerBuilder.RegisterType<VGtimeSettings>().As<IVGtimeSettings>();

            containerBuilder.RegisterInstance(DefaultImageLoader.Instance);

            containerBuilder.RegisterType<SplashScreenViewModel>();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<DetailViewModel>();
            containerBuilder.RegisterType<StrategyViewModel>();
            containerBuilder.RegisterType<CommentViewModel>();
            containerBuilder.RegisterType<SearchViewModel>();

            return containerBuilder.Build();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new SoftwareKobo.Services.NavigationService();
            navigationService.Configure(DetailViewKey, typeof(DetailView));
            navigationService.Configure(StrategyViewKey, typeof(StrategyView));
            navigationService.Configure(CommentViewKey, typeof(CommentView));
            navigationService.Configure(SearchViewKey, typeof(SearchView));
            return navigationService;
        }
    }
}