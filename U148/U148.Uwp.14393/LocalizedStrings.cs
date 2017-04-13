using Windows.ApplicationModel.Resources;

namespace U148.Uwp
{
    internal static class LocalizedStrings
    {
        private const string CommentViewReswName = "CommentView";

        private const string LoginViewReswName = "LoginView";

        internal static string SendCommentSuccess => ResourceLoader.GetForCurrentView(CommentViewReswName).GetString("SendCommentSuccess");

        private const string SettingViewReswName = "SettingView";
        internal static string ClearImageCacheFinish => ResourceLoader.GetForCurrentView(SettingViewReswName).GetString("ClearImageCacheFinish");

        internal static string EmailFormatError => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("EmailFormatError");

        internal static string EmailRequired => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("EmailRequired");

        internal static string LoginSuccess => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("LoginSuccess");

        internal static string PasswordLengthError => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("PasswordLengthError");

        internal static string PasswordRequired => ResourceLoader.GetForCurrentView(LoginViewReswName).GetString("PasswordRequired");

        internal static string PleaseInputComment => ResourceLoader.GetForCurrentView(CommentViewReswName).GetString("PleaseInputComment");
    }
}