using System;
using Windows.ApplicationModel.Resources;

namespace U148.Uwp
{
    internal static class LocalizedStrings
    {
        private const string ArticleCategoryReswName = "ArticleCategory";

        private const string CommentViewReswName = "CommentView";

        private const string LoginViewReswName = "LoginView";

        private const string MainViewReswName = "MainView";

        private const string SettingViewReswName = "SettingView";

        internal static string Audio => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Audio");

        internal static string ClearImageCacheFinish => ResourceLoader.GetForCurrentView(SettingViewReswName).GetString("ClearImageCacheFinish");

        internal static string ClearSinaWeiboAuthenticationSuccess => ResourceLoader.GetForCurrentView(SettingViewReswName).GetString("ClearSinaWeiboAuthenticationSuccess");

        internal static string EmailFormatError => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("EmailFormatError");

        internal static string EmailRequired => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("EmailRequired");

        internal static string Fair => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Fair");

        internal static string Game => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Game");

        internal static string Home => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Home");

        internal static string Image => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Image");

        internal static string LoginSuccess => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("LoginSuccess");

        internal static string LogoutSuccess => ResourceLoader.GetForCurrentView(MainViewReswName).GetString("LogoutSuccess");

        internal static string Mix => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Mix");

        internal static string PasswordLengthError => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("PasswordLengthError");

        internal static string PasswordRequired => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("PasswordRequired");

        internal static string Piao => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Piao");

        internal static string PleaseInputComment => ResourceLoader.GetForCurrentView(CommentViewReswName).GetString("PleaseInputComment");

        internal static string SendCommentSuccess => ResourceLoader.GetForCurrentView(CommentViewReswName).GetString("SendCommentSuccess");

        internal static string Tasty => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Tasty");

        internal static string Text => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Text");

        internal static string Video => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Video");

        internal static string Weibo => ResourceLoader.GetForCurrentView(ArticleCategoryReswName).GetString("Weibo");

        internal static string ShareSuccess
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal static string RefreshSuccess
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}