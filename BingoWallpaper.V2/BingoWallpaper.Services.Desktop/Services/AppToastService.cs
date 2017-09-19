using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FontAwesome.WPF;
using SoftwareKobo.Controls;
using SoftwareKobo.Extensions;

namespace BingoWallpaper.Services
{
    public class AppToastService : IAppToastService
    {
        private static Panel ToastContainer
        {
            get
            {
                return Application.Current.MainWindow.GetDescendantsOfType<Panel>().First(temp => temp.Name == "ToastContainer");
            }
        }

        public async void ShowError(string message)
        {
            var toastPrompt = CreateToastPrompt(message);
            toastPrompt.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEA, 0x17, 0x20));
            toastPrompt.Icon = new FontAwesome.WPF.FontAwesome()
            {
                Icon = FontAwesomeIcon.Close
            };
            ToastContainer.Children.Add(toastPrompt);
            await toastPrompt.ShowAsync();
            ToastContainer.Children.Remove(toastPrompt);
        }

        public async void ShowInformation(string message)
        {
            var toastPrompt = CreateToastPrompt(message);
            toastPrompt.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0, 0x9C, 0xF3));
            toastPrompt.Icon = new FontAwesome.WPF.FontAwesome()
            {
                Icon = FontAwesomeIcon.InfoCircle
            };
            ToastContainer.Children.Add(toastPrompt);
            await toastPrompt.ShowAsync();
            ToastContainer.Children.Remove(toastPrompt);
        }

        public async void ShowMessage(string message)
        {
            var toastPrompt = CreateToastPrompt(message);
            toastPrompt.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x13, 0xC0, 0x4D));
            toastPrompt.Icon = new FontAwesome.WPF.FontAwesome()
            {
                Icon = FontAwesomeIcon.Check
            };
            ToastContainer.Children.Add(toastPrompt);
            await toastPrompt.ShowAsync();
            ToastContainer.Children.Remove(toastPrompt);
        }

        public async void ShowWarning(string message)
        {
            var toastPrompt = CreateToastPrompt(message);
            toastPrompt.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xC1, 0));
            toastPrompt.Icon = new FontAwesome.WPF.FontAwesome()
            {
                Icon = FontAwesomeIcon.Warning
            };
            ToastContainer.Children.Add(toastPrompt);
            await toastPrompt.ShowAsync();
            ToastContainer.Children.Remove(toastPrompt);
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