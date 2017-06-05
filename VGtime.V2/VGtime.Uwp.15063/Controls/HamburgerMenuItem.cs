using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Controls
{
    public class HamburgerMenuItem : Button
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(HamburgerMenuItem), new PropertyMetadata(default(IconElement)));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(HamburgerMenuItem), new PropertyMetadata(default(string)));

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

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
    }
}