using System.Windows;
using System.Windows.Controls;

namespace SoftwareKobo.Helpers
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false, OnAttachChanged));

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnPasswordChanged));

        private static readonly DependencyProperty IsUpdatingProperty = DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false));

        public static string GetPassword(PasswordBox obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(PasswordBox obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        private static bool GetIsUpdating(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUpdatingProperty);
        }

        private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (PasswordBox)d;

            if ((bool)e.OldValue)
            {
                obj.PasswordChanged -= PasswordChanged;
            }
            if ((bool)e.NewValue)
            {
                obj.PasswordChanged += PasswordChanged;
            }
        }

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (PasswordBox)d;
            var value = (string)e.NewValue;

            obj.PasswordChanged -= PasswordChanged;
            if (!GetIsUpdating(obj))
            {
                obj.Password = value;
            }
            obj.PasswordChanged += PasswordChanged;
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
        }

        private static void SetIsUpdating(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUpdatingProperty, value);
        }
    }
}