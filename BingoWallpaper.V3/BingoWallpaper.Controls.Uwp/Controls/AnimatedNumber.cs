using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
using WinRTXamlToolkit.AwaitableUI;

namespace BingoWallpaper.Controls
{
    [ContentProperty(Name = nameof(Value))]
    [TemplatePart(Name = ValuePresenterTemplateName, Type = typeof(ContentPresenter))]
    public class AnimatedNumber : Control
    {
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(nameof(Duration), typeof(Duration), typeof(AnimatedNumber), new PropertyMetadata(default(Duration)));

        public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register(nameof(StringFormat), typeof(string), typeof(AnimatedNumber), new PropertyMetadata(default(string), StringFormatChanged));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(object), typeof(AnimatedNumber), new PropertyMetadata(default(double?), ValueChanged));

        private const string ValuePresenterTemplateName = "PART_ValuePresenter";

        private ContentPresenter _valuePresenter;

        public AnimatedNumber()
        {
            DefaultStyleKey = typeof(AnimatedNumber);
        }

        public Duration Duration
        {
            get
            {
                return (Duration)GetValue(DurationProperty);
            }
            set
            {
                SetValue(DurationProperty, value);
            }
        }

        public string StringFormat
        {
            get
            {
                return (string)GetValue(StringFormatProperty);
            }
            set
            {
                SetValue(StringFormatProperty, value);
            }
        }

        public double? Value
        {
            get
            {
                return (double?)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _valuePresenter = (ContentPresenter)GetTemplateChild(ValuePresenterTemplateName);

            UpdatePresenter(Value);
        }

        private static void StringFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (AnimatedNumber)d;

            obj.UpdatePresenter(obj.Value);
        }

        private static async void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (AnimatedNumber)d;
            if (obj._valuePresenter == null)
            {
                return;
            }

            var oldValue = (double?)e.OldValue;
            var newValue = (double?)e.NewValue;

            if (!oldValue.HasValue || !newValue.HasValue)
            {
                obj.UpdatePresenter(newValue);
                return;
            }

            var animatedNumberBridge = new AnimatedNumberBridge(value =>
            {
                obj.UpdatePresenter(value);
            });

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = oldValue.Value,
                To = newValue.Value,
                Duration = obj.Duration,
                EasingFunction = new ExponentialEase()
                {
                    EasingMode = EasingMode.EaseInOut
                },
                EnableDependentAnimation = true
            };
            Storyboard.SetTarget(animation, animatedNumberBridge);
            Storyboard.SetTargetProperty(animation, "Value");
            storyboard.Children.Add(animation);
            await storyboard.BeginAsync();

            obj.UpdatePresenter(obj.Value);
        }

        private void UpdatePresenter(double? value)
        {
            if (_valuePresenter != null)
            {
                if (StringFormat == null || !value.HasValue)
                {
                    _valuePresenter.Content = value;
                }
                else
                {
                    _valuePresenter.Content = value.Value.ToString(StringFormat);
                }
            }
        }
    }
}