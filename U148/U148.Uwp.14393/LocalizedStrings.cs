using Windows.ApplicationModel.Resources;

namespace U148.Uwp
{
    internal static class LocalizedStrings
    {
        private const string ArticleCategoryReswName = "ArticleCategory";

        private const string CommentViewReswName = "CommentView";

        private const string LoginViewReswName = "LoginView";

        private const string SettingViewReswName = "SettingView";

        private const string MainViewReswName = "MainView";

        internal static string Audio
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Audio");
            }
        }

        internal static string LogoutSuccess => ResourceLoader.GetForCurrentView(MainViewReswName).GetString("LogoutSuccess");

        internal static string ClearImageCacheFinish => ResourceLoader.GetForCurrentView(SettingViewReswName).GetString("ClearImageCacheFinish");

        internal static string EmailFormatError => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("EmailFormatError");

        internal static string EmailRequired => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("EmailRequired");

        internal static string Fair
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Fair");
            }
        }

        internal static string Game
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Game");
            }
        }

        internal static string Home => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Home");

        internal static string Image
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Image");
            }
        }

        internal static string LoginSuccess => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("LoginSuccess");

        internal static string Mix
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Mix");
            }
        }

        internal static string PasswordLengthError => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("PasswordLengthError");

        internal static string PasswordRequired => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("PasswordRequired");

        internal static string Piao
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Piao");
            }
        }

        internal static string PleaseInputComment => ResourceLoader.GetForCurrentView(CommentViewReswName).GetString("PleaseInputComment");

        internal static string SendCommentSuccess => ResourceLoader.GetForCurrentView(CommentViewReswName).GetString("SendCommentSuccess");

        internal static string Tasty
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Tasty");
            }
        }

        internal static string Text
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Text");
            }
        }

        internal static string Video
        {
            get
            {
                return ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Video");
            }
        }

        internal static string Weibo => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Weibo");
    }
}