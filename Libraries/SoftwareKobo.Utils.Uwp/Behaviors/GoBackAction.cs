using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.Extensions;

namespace SoftwareKobo.Behaviors
{
    public class GoBackAction : DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            var frame = (sender as DependencyObject)?.GetFirstAncestorOfType<Frame>() ?? Window.Current.Content?.GetFirstDescendantOfType<Frame>();
            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}