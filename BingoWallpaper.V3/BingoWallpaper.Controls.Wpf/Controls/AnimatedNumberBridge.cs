using System;
using System.Windows;

namespace BingoWallpaper.Controls
{
    internal class AnimatedNumberBridge : DependencyObject
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(double), typeof(AnimatedNumberBridge), new PropertyMetadata(default(double), ValueChanged));

        private readonly Action<double> _action;

        internal AnimatedNumberBridge(Action<double> action)
        {
            _action = action;
        }

        public double Value
        {
            get
            {
                return (double)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (AnimatedNumberBridge)d;
            var value = (double)e.NewValue;

            obj._action(value);
        }
    }
}