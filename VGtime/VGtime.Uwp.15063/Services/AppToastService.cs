using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using SoftwareKobo.Controls;
using SoftwareKobo.Icons.FontAwesome;
using VGtime.Uwp.Views;

namespace VGtime.Uwp.Services
{
    public class AppToastService : IAppToastService
    {
        private static Panel ToastPromptContainer
        {
            get
            {
                var rootView = (RootView)Window.Current.Content;
                return rootView.ToastPromptContainer;
            }
        }

        public async void ShowError(string message)
        {
            var toastPrompt = CreateToastPrompt(message);
            toastPrompt.Background = new SolidColorBrush(Color.FromArgb(255, 234, 23, 32));
            toastPrompt.Icon = new FontAwesomeIcon(FontAwesomeSymbol.Close);
            ToastPromptContainer.Children.Add(toastPrompt);
            await toastPrompt.ShowAsync();
            ToastPromptContainer.Children.Remove(toastPrompt);
        }

        public async void ShowInformation(string message)
        {
            var toastPrompt = CreateToastPrompt(message);
            toastPrompt.Background = new SolidColorBrush(Color.FromArgb(255, 0, 156, 243));
            toastPrompt.Icon = new FontAwesomeIcon(FontAwesomeSymbol.InfoCircle);
            ToastPromptContainer.Children.Add(toastPrompt);
            await toastPrompt.ShowAsync();
            ToastPromptContainer.Children.Remove(toastPrompt);
        }

        public async void ShowMessage(string message)
        {
            var toastPrompt = CreateToastPrompt(message);
            toastPrompt.Background = new SolidColorBrush(Color.FromArgb(255, 19, 192, 77));
            toastPrompt.Icon = new FontAwesomeIcon(FontAwesomeSymbol.Check);
            ToastPromptContainer.Children.Add(toastPrompt);
            await toastPrompt.ShowAsync();
            ToastPromptContainer.Children.Remove(toastPrompt);
        }

        public async void ShowWarning(string message)
        {
            var toastPrompt = CreateToastPrompt(message);
            toastPrompt.Background = new SolidColorBrush(Color.FromArgb(255, 255, 193, 0));
            toastPrompt.Icon = new FontAwesomeIcon(FontAwesomeSymbol.Warning);
            ToastPromptContainer.Children.Add(toastPrompt);
            await toastPrompt.ShowAsync();
            ToastPromptContainer.Children.Remove(toastPrompt);
        }

        private static ToastPrompt CreateToastPrompt(string message)
        {
            return new ToastPrompt()
            {
                Foreground = new SolidColorBrush(Colors.White),
                Message = message,
                Duration = TimeSpan.FromSeconds(2)
            };
        }
    }
}