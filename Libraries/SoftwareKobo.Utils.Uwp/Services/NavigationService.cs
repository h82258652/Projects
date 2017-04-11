using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.Extensions;

namespace SoftwareKobo.Services
{
    public class NavigationService : INavigationService
    {
        public const string RootPageKey = "-- ROOT --";

        public const string UnknownPageKey = "-- UNKNOWN --";

        protected readonly Dictionary<string, Type> PagesByKey = new Dictionary<string, Type>();

        public string CurrentPageKey
        {
            get
            {
                lock (PagesByKey)
                {
                    var rootFrame = RootFrame;

                    if (rootFrame.BackStackDepth <= 0)
                    {
                        return RootPageKey;
                    }

                    if (rootFrame.Content == null)
                    {
                        return UnknownPageKey;
                    }

                    var currentType = rootFrame.Content.GetType();

                    if (!PagesByKey.ContainsValue(currentType))
                    {
                        return UnknownPageKey;
                    }

                    var item = PagesByKey.FirstOrDefault(temp => temp.Value == currentType);

                    return item.Key;
                }
            }
        }

        protected virtual Frame RootFrame => Window.Current.Content?.GetFirstDescendantOfType<Frame>();

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
            var rootFrame = RootFrame;
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

                var rootFrame = RootFrame;
                rootFrame?.Navigate(PagesByKey[pageKey], parameter);
            }
        }
    }
}