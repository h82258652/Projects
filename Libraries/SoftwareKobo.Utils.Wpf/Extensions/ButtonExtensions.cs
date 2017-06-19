using System;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls.Primitives;

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
                var automationPeer = UIElementAutomationPeer.CreatePeerForElement(button);
                var invokeProvider = automationPeer?.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProvider?.Invoke();
            }
        }
    }
}