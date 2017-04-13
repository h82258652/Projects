using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using SoftwareKobo.Extensions;
using U148.Uwp.Messages;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using WinRTXamlToolkit.AwaitableUI;

namespace U148.Uwp.Views
{
    public sealed partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public async void Hide()
        {
            await HideAsync();
        }

        public async Task HideAsync()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = ActualHeight,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CircleEase()
                {
                    EasingMode = EasingMode.EaseOut
                }
            };
            Storyboard.SetTarget(animation, RootGrid);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
            storyboard.Children.Add(animation);
            await storyboard.BeginAsync();
        }

        public async void Show()
        {
            await ShowAsync();
        }

        public async Task ShowAsync()
        {
            await this.WaitForNonZeroSizeAsync();

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = ActualHeight,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CircleEase()
                {
                    EasingMode = EasingMode.EaseOut
                }
            };
            Storyboard.SetTarget(animation, RootGrid);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
            storyboard.Children.Add(animation);
            await storyboard.BeginAsync();
        }

        private void EmailTextBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            PasswordBox.Focus(FocusState.Programmatic);
        }

        private void LoginView_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<LoginFailedMessage>(this, message =>
            {
                EmailTextBox.Focus(FocusState.Programmatic);
            });
        }

        private void LoginView_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }

        private void PasswordBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                e.Handled = true;
                LoginButton.Focus(FocusState.Programmatic);
                LoginButton.PerformClick();
            }
        }
    }
}