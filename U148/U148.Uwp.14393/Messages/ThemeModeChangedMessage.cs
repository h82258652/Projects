using System;
using GalaSoft.MvvmLight.Messaging;
using U148.Models;

namespace U148.Uwp.Messages
{
    public class ThemeModeChangedMessage : MessageBase
    {
        public ThemeModeChangedMessage(ThemeMode newThemeMode)
        {
            if (Enum.IsDefined(typeof(ThemeMode), newThemeMode) == false)
            {
                throw new ArgumentOutOfRangeException(nameof(newThemeMode));
            }

            NewThemeMode = newThemeMode;
        }

        public ThemeMode NewThemeMode
        {
            get;
        }
    }
}