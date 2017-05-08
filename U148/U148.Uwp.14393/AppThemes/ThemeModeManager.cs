using System;
using GalaSoft.MvvmLight;
using U148.Configuration;
using U148.Models;
using Weakly;

namespace U148.Uwp.AppThemes
{
    public class ThemeModeManager : ObservableObject, IThemeModeManager
    {
        private static readonly WeakEventSource<CurrentThemeChangedEventArgs> EventSource = new WeakEventSource<CurrentThemeChangedEventArgs>();

        private readonly IU148UwpSettings _u148UwpSettings;

        public ThemeModeManager(IU148UwpSettings u148UwpSettings)
        {
            EventSource.Add((sender, e) =>
            {
                RaisePropertyChanged(() => CurrentTheme);
            });

            _u148UwpSettings = u148UwpSettings;
        }

        public static event EventHandler<CurrentThemeChangedEventArgs> CurrentThemeChanged;

        public ThemeMode CurrentTheme
        {
            get
            {
                return _u148UwpSettings.ThemeMode;
            }
            set
            {
                if (Enum.IsDefined(typeof(ThemeMode), value) == false)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (_u148UwpSettings.ThemeMode != value)
                {
                    _u148UwpSettings.ThemeMode = value;
                    var args = new CurrentThemeChangedEventArgs(value);
                    EventSource.Raise(this, args);
                    RaisePropertyChanged();
                    CurrentThemeChanged?.Invoke(this, args);
                }
            }
        }
    }
}