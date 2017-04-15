using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace U148.Uwp.Controls
{
    public class HamburgerMenuItem : Button
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(HamburgerMenuItem), new PropertyMetadata(default(IconElement)));

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(HamburgerMenuItem), new PropertyMetadata(default(string)));

        public HamburgerMenuItem()
        {
            DefaultStyleKey = typeof(HamburgerMenuItem);
        }

        public IconElement Icon
        {
            get
            {
                return (IconElement)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public string Label
        {
            get
            {
                return (string)GetValue(LabelProperty);
            }
            set
            {
                SetValue(LabelProperty, value);
            }
        }
    }
}