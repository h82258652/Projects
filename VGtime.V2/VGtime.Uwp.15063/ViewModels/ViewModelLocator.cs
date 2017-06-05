using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.Controls;
using SoftwareKobo.Services;
using VGtime.Configuration;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewModels.Games;
using VGtime.Uwp.ViewModels.Image;
using VGtime.Uwp.ViewModels.Message;
using VGtime.Uwp.ViewModels.Post;
using VGtime.Uwp.ViewModels.Settings;
using VGtime.Uwp.ViewModels.Users;
using VGtime.Uwp.Views;
using VGtime.Uwp.Views.Games;
using VGtime.Uwp.Views.Image;
using VGtime.Uwp.Views.Settings;

namespace VGtime.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string AboutViewKey = "About";

        public const string ArticleDetailViewKey = "ArticleDetail";

        public const string CommentViewKey = "Comment";

        public const string GameDetailViewKey = "GameDetail";

        public const string GamePhotoViewKey = "GamePhoto";

        public const string GameRelationViewKey = "GameRelation";

        public const string GameScoreViewKey = "GameScore";

        public const string GameStrategySetViewKey = "GameStrategySet";

        public const string ImagePagerViewKey = "ImagePager";

        public const string SearchViewKey = "Search";

        public const string SettingViewKey = "Setting";

        public const string ShowCoverViewKey = "ShowCover";

        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public ArticleDetailViewModel ArticleDetail => ServiceLocator.Current.GetInstance<ArticleDetailViewModel>();

        public BasicInformationViewModel BasicInformation => ServiceLocator.Current.GetInstance<BasicInformationViewModel>();

        public CitysViewModel Citys => ServiceLocator.Current.GetInstance<CitysViewModel>();

        public CommentViewModel Comment => ServiceLocator.Current.GetInstance<CommentViewModel>();

        public GameDetailViewModel GameDetail => ServiceLocator.Current.GetInstance<GameDetailViewModel>();

        public GamePhotoViewModel GamePhoto => ServiceLocator.Current.GetInstance<GamePhotoViewModel>();

        public GameRelationViewModel GameRelation => ServiceLocator.Current.GetInstance<GameRelationViewModel>();

        public GameScoreViewModel GameScore => ServiceLocator.Current.GetInstance<GameScoreViewModel>();

        public GameStrategySetViewModel GameStrategySet => ServiceLocator.Current.GetInstance<GameStrategySetViewModel>();

        public ImagePagerViewModel ImagePager => ServiceLocator.Current.GetInstance<ImagePagerViewModel>();

        public InvitationViewModel Invitation => ServiceLocator.Current.GetInstance<InvitationViewModel>();

        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public MessageViewModel Message => ServiceLocator.Current.GetInstance<MessageViewModel>();

        public OldGameStrategyViewModel OldGameStrategy => ServiceLocator.Current.GetInstance<OldGameStrategyViewModel>();

        public RegisterViewModel Register => ServiceLocator.Current.GetInstance<RegisterViewModel>();

        public RetrievePasswordViewModel RetrievePassword => ServiceLocator.Current.GetInstance<RetrievePasswordViewModel>();

        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public SelectFriendsViewModel SelectFriends => ServiceLocator.Current.GetInstance<SelectFriendsViewModel>();

        public SelectGameViewModel SelectGame => ServiceLocator.Current.GetInstance<SelectGameViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();

        public ShortEditorViewModel ShortEditor => ServiceLocator.Current.GetInstance<ShortEditorViewModel>();

        public ShowCoverViewModel ShowCover => ServiceLocator.Current.GetInstance<ShowCoverViewModel>();

        public SignViewModel Sign => ServiceLocator.Current.GetInstance<SignViewModel>();

        public UpdateEmailViewModel UpdateEmail => ServiceLocator.Current.GetInstance<UpdateEmailViewModel>();

        public UpdatePasswordViewModel UpdatePassword => ServiceLocator.Current.GetInstance<UpdatePasswordViewModel>();

        public UpdateUsernameViewModel UpdateUsername => ServiceLocator.Current.GetInstance<UpdateUsernameViewModel>();

        public WelcomeViewModel Welcome => ServiceLocator.Current.GetInstance<WelcomeViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());
            containerBuilder.RegisterType<InitService>().As<IInitService>();
            containerBuilder.RegisterType<HomeService>().As<IHomeService>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<GameService>().As<IGameService>();
            containerBuilder.RegisterType<PostService>().As<IPostService>();
            containerBuilder.RegisterType<AppToastService>().As<IAppToastService>();
            containerBuilder.RegisterType<StoreService>().As<IStoreService>();
            containerBuilder.RegisterType<VGtimeFileService>().As<IVGtimeFileService>();
            containerBuilder.RegisterType<VGtimeShareService>().As<IVGtimeShareService>();

            containerBuilder.RegisterType<VGtimeSettings>().As<IVGtimeSettings>();

            containerBuilder.RegisterInstance(DefaultImageLoader.Instance);

            containerBuilder.RegisterType<AboutViewModel>();
            containerBuilder.RegisterType<ArticleDetailViewModel>();
            containerBuilder.RegisterType<GameDetailViewModel>();
            containerBuilder.RegisterType<GamePhotoViewModel>();
            containerBuilder.RegisterType<GameScoreViewModel>();
            containerBuilder.RegisterType<GameStrategySetViewModel>();
            containerBuilder.RegisterType<LoginViewModel>();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<SearchViewModel>();
            containerBuilder.RegisterType<SettingViewModel>();
            containerBuilder.RegisterType<WelcomeViewModel>();
            containerBuilder.RegisterType<OldGameStrategyViewModel>();
            containerBuilder.RegisterType<CommentViewModel>();
            containerBuilder.RegisterType<ImagePagerViewModel>();
            containerBuilder.RegisterType<ShowCoverViewModel>();

            return containerBuilder.Build();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new SoftwareKobo.Services.NavigationService();
            navigationService.Configure(ArticleDetailViewKey, typeof(ArticleDetailView));
            navigationService.Configure(CommentViewKey, typeof(CommentView));
            navigationService.Configure(GameDetailViewKey, typeof(GameDetailView));
            navigationService.Configure(GamePhotoViewKey, typeof(GamePhotoView));
            navigationService.Configure(GameScoreViewKey, typeof(GameScoreView));
            navigationService.Configure(GameStrategySetViewKey, typeof(GameStrategySetView));
            navigationService.Configure(ImagePagerViewKey, typeof(ImagePagerView));
            navigationService.Configure(SearchViewKey, typeof(SearchView));
            navigationService.Configure(GameRelationViewKey, typeof(GameRelationView));
            navigationService.Configure(AboutViewKey, typeof(AboutView));
            navigationService.Configure(SettingViewKey, typeof(SettingView));
            navigationService.Configure(ShowCoverViewKey, typeof(ShowCoverView));
            return navigationService;
        }
    }
}