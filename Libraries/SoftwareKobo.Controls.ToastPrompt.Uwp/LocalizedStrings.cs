using Windows.ApplicationModel.Resources;

namespace SoftwareKobo.Controls
{
    internal static class LocalizedStrings
    {
        internal static string DurationNotTimeSpanExceptionMessage => ResourceLoader.GetForCurrentView("SoftwareKobo.Controls.ToastPrompt.Uwp/Resources").GetString("DurationNotTimeSpanExceptionMessage");
    }
}