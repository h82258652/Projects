using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace BingoWallpaper.Wpf.Behaviors
{
    public class ScrollViewerBehavior : Behavior<ScrollViewer>, ICommandSource
    {
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(ScrollViewerBehavior), new PropertyMetadata(default(object)));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ScrollViewerBehavior), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty CommandTargetProperty = DependencyProperty.Register(nameof(CommandTarget), typeof(IInputElement), typeof(ScrollViewerBehavior), new PropertyMetadata(default(IInputElement)));

        public ScrollViewerBehavior()
        {
            throw new NotImplementedException();
        }

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public object CommandParameter
        {
            get
            {
                return GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        public IInputElement CommandTarget
        {
            get
            {
                return (IInputElement)GetValue(CommandTargetProperty);
            }
            set
            {
                SetValue(CommandTargetProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.ScrollChanged += AssociatedObject_ScrollChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.ScrollChanged -= AssociatedObject_ScrollChanged;
        }

        private void AssociatedObject_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (AssociatedObject.VerticalOffset + e.ViewportHeight >= e.ExtentHeight)
            {
                throw new NotImplementedException();
            }

            var command = Command;
            var commandParameter = CommandParameter;
            var commandTarget = CommandTarget;
            if (command is RoutedCommand routedCommand && routedCommand.CanExecute(commandParameter, commandTarget))
            {
                routedCommand.Execute(commandParameter, commandTarget);
            }
            else if (command != null && command.CanExecute(commandParameter))
            {
                command.Execute(commandParameter);
            }
        }
    }
}