﻿using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SoftwareKobo.Controls;
using VGtime.Configuration;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewModels.Games;
using VGtime.Uwp.ViewModels.Settings;
using VGtime.Uwp.ViewModels.Users;
using VGtime.Uwp.Views;

namespace VGtime.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string ArticleDetailViewKey = "ArticleDetail";

        public const string CommentViewKey = "Comment";

        public const string SearchViewKey = "Search";

        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public ArticleDetailViewModel ArticleDetail => ServiceLocator.Current.GetInstance<ArticleDetailViewModel>();

        public CommentViewModel Comment => ServiceLocator.Current.GetInstance<CommentViewModel>();

        public GameDetailViewModel GameDetail => ServiceLocator.Current.GetInstance<GameDetailViewModel>();

        public GamePhotoViewModel GamePhoto => ServiceLocator.Current.GetInstance<GamePhotoViewModel>();

        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();

        public WelcomeViewModel Welcome => ServiceLocator.Current.GetInstance<WelcomeViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());
            containerBuilder.RegisterType<InitService>().As<IInitService>();
            containerBuilder.RegisterType<HomeService>().As<IHomeService>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<GameService>().As<IGameService>();
            containerBuilder.RegisterType<AppToastService>().As<IAppToastService>();

            containerBuilder.RegisterType<VGtimeSettings>().As<IVGtimeSettings>();

            containerBuilder.RegisterInstance(DefaultImageLoader.Instance);

            containerBuilder.RegisterType<AboutViewModel>();
            containerBuilder.RegisterType<ArticleDetailViewModel>();
            containerBuilder.RegisterType<GameDetailViewModel>();
            containerBuilder.RegisterType<GamePhotoViewModel>();
            containerBuilder.RegisterType<LoginViewModel>();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<SearchViewModel>();
            containerBuilder.RegisterType<SettingViewModel>();
            containerBuilder.RegisterType<WelcomeViewModel>();

            return containerBuilder.Build();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure(SearchViewKey, typeof(SearchView));
            navigationService.Configure(ArticleDetailViewKey, typeof(ArticleDetailView));
            navigationService.Configure(CommentViewKey, typeof(CommentView));
            return navigationService;
        }
    }
}