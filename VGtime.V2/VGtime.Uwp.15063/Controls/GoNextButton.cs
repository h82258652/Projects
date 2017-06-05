using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Controls
{
    public sealed class GoNextButton : Button
    {
        public static readonly DependencyProperty IsNextIconVisibleProperty = DependencyProperty.Register(nameof(IsNextIconVisible), typeof(bool), typeof(GoNextButton), new PropertyMetadata(true));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(GoNextButton), new PropertyMetadata(default(string)));

        public GoNextButton()
        {
            DefaultStyleKey = typeof(GoNextButton);
        }

        public bool IsNextIconVisible
        {
            get
            {
                return (bool)GetValue(IsNextIconVisibleProperty);
            }
            set
            {
                SetValue(IsNextIconVisibleProperty, value);
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