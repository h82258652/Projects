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
        public const string AblumDetailViewKey = "AblumDetail";

        public const string AblumListViewKey = "AblumList";

        public const string CommentViewKey = "Comment";

        public const string DetailViewKey = "Detail";

        public const string GameDetailViewKey = "GameDetail";

        public const string OldStrategyViewKey = "OldStrategy";

        public const string RelationListViewKey = "RelationList";

        public const string ScoreListViewKey = "ScoreList";

        public const string SearchViewKey = "Search";

        public const string StrategyViewKey = "Strategy";

        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public AblumDetailViewModel AblumDetail => ServiceLocator.Current.GetInstance<AblumDetailViewModel>();

        public AblumListViewModel AblumList => ServiceLocator.Current.GetInstance<AblumListViewModel>();

        public CommentViewModel Comment => ServiceLocator.Current.GetInstance<CommentViewModel>();

        public DetailViewModel Detail => ServiceLocator.Current.GetInstance<DetailViewModel>();

        public GameDetailViewModel GameDetail => ServiceLocator.Current.GetInstance<GameDetailViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public OldStrategyViewModel OldStrategy => ServiceLocator.Current.GetInstance<OldStrategyViewModel>();

        public RelationListViewModel RelationList => ServiceLocator.Current.GetInstance<RelationListViewModel>();

        public ScoreListViewModel ScoreList => ServiceLocator.Current.GetInstance<ScoreListViewModel>();

        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public SplashScreenViewModel SplashScreen => ServiceLocator.Current.GetInstance<SplashScreenViewModel>();

        public StrategyViewModel Strategy => ServiceLocator.Current.GetInstance<StrategyViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());
            containerBuilder.RegisterType<PostService>().As<IPostService>();
            containerBuilder.RegisterType<AppToastService>().As<IAppToastService>();
            containerBuilder.RegisterType<VGtimeFileService>().As<IVGtimeFileService>();

            containerBuilder.RegisterType<VGtimeSettings>().As<IVGtimeSettings>();

            containerBuilder.RegisterInstance(DefaultImageLoader.Instance);

            containerBuilder.RegisterType<SplashScreenViewModel>();
            containerBuilder.RegisterType<MainViewModel>().SingleInstance();
            containerBuilder.RegisterType<DetailViewModel>();
            containerBuilder.RegisterType<StrategyViewModel>();
            containerBuilder.RegisterType<OldStrategyViewModel>();
            containerBuilder.RegisterType<CommentViewModel>();
            containerBuilder.RegisterType<SearchViewModel>();
            containerBuilder.RegisterType<GameDetailViewModel>();
            containerBuilder.RegisterType<AblumListViewModel>();
            containerBuilder.RegisterType<AblumDetailViewModel>();
            containerBuilder.RegisterType<RelationListViewModel>();
            containerBuilder.RegisterType<ScoreListViewModel>();

            return containerBuilder.Build();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new SoftwareKobo.Services.NavigationService();
            navigationService.Configure(DetailViewKey, typeof(DetailView));
            navigationService.Configure(StrategyViewKey, typeof(StrategyView));
            navigationService.Configure(OldStrategyViewKey, typeof(OldStrategyView));
            navigationService.Configure(CommentViewKey, typeof(CommentView));
            navigationService.Configure(SearchViewKey, typeof(SearchView));
            navigationService.Configure(GameDetailViewKey, typeof(GameDetailView));
            navigationService.Configure(AblumListViewKey, typeof(AblumListView));
            navigationService.Configure(AblumDetailViewKey, typeof(AblumDetailView));
            navigationService.Configure(RelationListViewKey, typeof(RelationListView));
            navigationService.Configure(ScoreListViewKey, typeof(ScoreListView));
            return navigationService;
        }
    }
}