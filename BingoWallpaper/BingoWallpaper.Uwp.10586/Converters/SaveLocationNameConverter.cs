﻿using System;
using BingoWallpaper.Models;
using Windows.UI.Xaml.Data;

namespace BingoWallpaper.Uwp.Converters
{
    public class SaveLocationNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is SaveLocation)
            {
                var saveLocation = (SaveLocation)value;
                switch (saveLocation)
                {
                    case SaveLocation.PictureLibrary:
                        return LocalizedStrings.PictureLibrary;

                    case SaveLocation.ChooseEveryTime:
                        return LocalizedStrings.ChooseEveryTime;

                    case SaveLocation.SavedPictures:
                        return LocalizedStrings.SavedPictures;

                    default:
                        return value;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}