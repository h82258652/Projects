using System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;

namespace SoftwareKobo.Extensions
{
    public static class ButtonExtensions
    {
        public static void PerformClick(this ButtonBase button)
        {
            if (button == null)
            {
                throw new ArgumentNullException(nameof(button));
            }

            if (button.IsEnabled)
            {
                var automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(button);
                var invokeProvider = automationPeer?.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProvider?.Invoke();
            }
        }
    }
}