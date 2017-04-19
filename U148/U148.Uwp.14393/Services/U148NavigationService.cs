using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using U148.Uwp.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.Extensions;

namespace U148.Uwp.Services
{
    public class U148NavigationService : INavigationService
    {
        public const string UnknownPageKey = "-- UNKNOWN --";

        protected readonly Dictionary<string, U148NavigationType> NavigationTypesByKey = new Dictionary<string, U148NavigationType>();

        protected readonly Dictionary<string, Type> PagesByKey = new Dictionary<string, Type>();

        public string CurrentPageKey
        {
            get
            {
                lock (PagesByKey)
                {
                    var masterDetailView = Window.Current.Content?.GetFirstDescendantOfType<MasterDetailView>();
                    if (masterDetailView == null)
                    {
                        return UnknownPageKey;
                    }

                    var frame = masterDetailView.IsDisplayDetail ? DetailFrame : MasterFrame;
                    if (frame.Content == null)
                    {
                        return UnknownPageKey;
                    }

                    var currentType = frame.Content.GetType();
                    if (!PagesByKey.ContainsValue(currentType))
                    {
                        return UnknownPageKey;
                    }

                    var item = PagesByKey.FirstOrDefault(temp => temp.Value == currentType);
                    return item.Key;
                }
            }
        }

        protected virtual Frame DetailFrame
        {
            get
            {
                return Window.Current.Content?.GetDescendantsOfType<Frame>().FirstOrDefault(temp => temp.Name == "DetailFrame");
            }
        }

        protected virtual Frame MasterFrame
        {
            get
            {
                return Window.Current.Content?.GetDescendantsOfType<Frame>().FirstOrDefault(temp => temp.Name == "MasterFrame");
            }
        }

        public void Configure(string key, Type pageType, U148NavigationType navigationType)
        {
            if (!Enum.IsDefined(typeof(U148NavigationType), navigationType))
            {
                throw new ArgumentOutOfRangeException(nameof(navigationType));
            }

            lock (PagesByKey)
            {
                lock (NavigationTypesByKey)
                {
                    if (PagesByKey.ContainsKey(key) || NavigationTypesByKey.ContainsKey(key))
                    {
                        throw new ArgumentException("This key is already used: " + key);
                    }

                    if (PagesByKey.Any(temp => temp.Value == pageType))
                    {
                        throw new ArgumentException("This type is already configured with key " + PagesByKey.First(temp => temp.Value == pageType).Key);
                    }

                    PagesByKey.Add(key, pageType);
                    NavigationTypesByKey.Add(key, navigationType);
                }
            }
        }

        public void GoBack()
        {
            var masterDetailView = Window.Current.Content?.GetFirstDescendantOfType<MasterDetailView>();
            if (masterDetailView == null)
            {
                return;
            }

            var frame = masterDetailView.IsDisplayDetail ? DetailFrame : MasterFrame;
            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
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

                lock (NavigationTypesByKey)
                {
                    switch (NavigationTypesByKey[pageKey])
                    {
                        case U148NavigationType.Master:
                            MasterFrame?.Navigate(PagesByKey[pageKey], parameter);
                            break;

                        case U148NavigationType.Detail:
                            DetailFrame?.Navigate(PagesByKey[pageKey], parameter);
                            break;
                    }
                }
            }
        }
    }
}