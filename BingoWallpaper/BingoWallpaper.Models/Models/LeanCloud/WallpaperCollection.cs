﻿using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace BingoWallpaper.Models.LeanCloud
{
    [ComVisible(false)]
    public class WallpaperCollection : ObservableCollection<Wallpaper>
    {
        public WallpaperCollection(int year, int month)
        {
            var viewMonth = new DateTime(year, month, 1);
            if (viewMonth < Constants.MinimumViewMonth)
            {
                throw new ArgumentOutOfRangeException(nameof(viewMonth));
            }

            Year = year;
            Month = month;
        }

        public int Month
        {
            get;
        }

        public int Year
        {
            get;
        }
    }
}