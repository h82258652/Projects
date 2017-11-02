using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using SoftwareKobo.Controls.Extensions;
using SoftwareKobo.Extensions;

namespace SoftwareKobo.Controls
{
    [TemplatePart(Name = RootGridTemplateName, Type = typeof(Grid))]
    [TemplatePart(Name = ContainerTemplateName, Type = typeof(ContentControl))]
    public class ToastPrompt : Control
    {
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(nameof(Duration), typeof(Duration), typeof(ToastPrompt), new PropertyMetadata(default(Duration), OnDurationChanged));

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(object), typeof(ToastPrompt), new PropertyMetadata(default(object)));

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof(Message), typeof(string), typeof(ToastPrompt), new PropertyMetadata(default(string)));

        private const string ContainerTemplateName = "PART_Container";

        private const string RootGridTemplateName = "PART_RootGrid";

        private ContentControl _container;

        private Grid _rootGrid;

        static ToastPrompt()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToastPrompt), new FrameworkPropertyMetadata(typeof(ToastPrompt)));
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

        public object Icon
        {
            get
            {
                return GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public string Message
        {
            get
            {
                return (string)GetValue(MessageProperty);
            }
            set
            {
                SetValue(MessageProperty, value);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _rootGrid = (Grid)GetTemplateChild(RootGridTemplateName);
            _container = (ContentControl)GetTemplateChild(ContainerTemplateName);
        }

        public async void Show()
        {
            await ShowAsync();
        }

        public async Task ShowAsync()
        {
            await this.WaitForNonZeroSizeAsync();

            var width = ActualWidth;

            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 0
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.5),
                    Value = 1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = Duration.TimeSpan + TimeSpan.FromSeconds(0.5),
                    Value = 1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = Duration.TimeSpan + TimeSpan.FromSeconds(1),
                    Value = 0
                });
                Storyboard.SetTarget(animation, _rootGrid);
                Storyboard.SetTargetProperty(animation, new PropertyPath(nameof(Opacity)));
                storyboard.Children.Add(animation);
            }
            {
                var animation = new ThicknessAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteThicknessKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = new Thickness(0, 0, 0 - width, 0)
                });
                animation.KeyFrames.Add(new EasingThicknessKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.5),
                    Value = new Thickness(),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseOut
                    }
                });
                animation.KeyFrames.Add(new DiscreteThicknessKeyFrame()
                {
                    KeyTime = Duration.TimeSpan + TimeSpan.FromSeconds(0.5),
                    Value = new Thickness()
                });
                animation.KeyFrames.Add(new EasingThicknessKeyFrame()
                {
                    KeyTime = Duration.TimeSpan + TimeSpan.FromSeconds(1),
                    Value = new Thickness(0, 0, 0 - width, 0),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseIn
                    }
                });
                Storyboard.SetTarget(animation, _container);
                Storyboard.SetTargetProperty(animation, new PropertyPath(nameof(Margin)));
                storyboard.Children.Add(animation);
            }
            await storyboard.BeginAsync();
            _container.Margin = new Thickness();
        }

        private static void OnDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var value = (Duration)e.NewValue;

            if (value.HasTimeSpan == false)
            {
                throw new ArgumentException(Properties.Resources.DurationNotTimeSpanExceptionMessage, nameof(Duration));
            }
        }
    }
}