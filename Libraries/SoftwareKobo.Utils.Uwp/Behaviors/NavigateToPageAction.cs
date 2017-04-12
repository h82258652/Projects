using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Microsoft.Xaml.Interactivity;
using WinRTXamlToolkit.Controls.Extensions;

namespace SoftwareKobo.Behaviors
{
    public class NavigateToPageAction : DependencyObject, IAction
    {
        public static readonly DependencyProperty ParameterProperty = DependencyProperty.Register(nameof(Parameter), typeof(object), typeof(NavigateToPageAction), new PropertyMetadata(default(object)));

        public static readonly DependencyProperty TargetPageProperty = DependencyProperty.Register(nameof(TargetPage), typeof(string), typeof(NavigateToPageAction), new PropertyMetadata(default(string)));

        public object Parameter
        {
            get
            {
                return GetValue(ParameterProperty);
            }
            set
            {
                SetValue(ParameterProperty, value);
            }
        }

        public string TargetPage
        {
            get
            {
                return (string)GetValue(TargetPageProperty);
            }
            set
            {
                SetValue(TargetPageProperty, value);
            }
        }

        protected virtual Frame RootFrame => Window.Current.Content?.GetFirstDescendantOfType<Frame>();

        public object Execute(object sender, object parameter)
        {
            if (string.IsNullOrEmpty(TargetPage))
            {
                return false;
            }

            var metadataProvider = Application.Current as IXamlMetadataProvider;
            var xamlType = metadataProvider?.GetXamlType(TargetPage);
            if (xamlType == null)
            {
                return false;
            }

            var navigateElement = (sender as DependencyObject)?.GetAncestors(true).OfType<INavigate>().FirstOrDefault();
            if (navigateElement != null)
            {
                return navigateElement.Navigate(xamlType.UnderlyingType);
            }
            else
            {
                var rootFrame = RootFrame;
                return rootFrame?.Navigate(xamlType.UnderlyingType, parameter);
            }
        }
    }
}