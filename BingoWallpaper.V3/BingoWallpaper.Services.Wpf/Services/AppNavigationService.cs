using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BingoWallpaper.Services
{
    public class AppNavigationService : IAppNavigationService
    {
        protected readonly Dictionary<string, Type> PagesByKey = new Dictionary<string, Type>();

        public void Configure(string key, Type pageType)
        {
            lock (PagesByKey)
            {
                if (PagesByKey.ContainsKey(key))
                {
                    throw new ArgumentException("This key is already used: " + key);
                }

                if (PagesByKey.Any(temp => temp.Value == pageType))
                {
                    throw new ArgumentException("This type is already configured with key " + PagesByKey.First(temp => temp.Value == pageType).Key);
                }

                PagesByKey.Add(key, pageType);
            }
        }

        public void GoBack()
        {
            var rootFrame = (Frame)Application.Current.MainWindow.FindName("RootFrame");
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            lock (PagesByKey)
            {
                if (!PagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException($"No such page: {pageKey}. Did you forget to call NavigationService.Configure?", nameof(pageKey));
                }

                var rootFrame = (Frame)Application.Current.MainWindow.FindName("RootFrame");
                var pageType = PagesByKey[pageKey];
                rootFrame?.Navigate(Activator.CreateInstance(pageType, parameter));
            }
        }
    }
}