using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Controls
{
    public sealed class GoNextButton : Button
    {
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(object), typeof(GoNextButton), new PropertyMetadata(null));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(GoNextButton), new PropertyMetadata(default(string)));

        public GoNextButton()
        {
            DefaultStyleKey = typeof(GoNextButton);
        }

        public int? Count
        {
            get
            {
                return (int?)GetValue(CountProperty);
            }
            set
            {
                SetValue(CountProperty, value);
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