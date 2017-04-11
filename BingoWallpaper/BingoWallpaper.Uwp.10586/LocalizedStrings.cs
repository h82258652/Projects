﻿using Windows.ApplicationModel.Resources;

namespace BingoWallpaper.Uwp
{
    internal static class LocalizedStrings
    {
        private const string ConstantsReswName = "Constants";

        internal static string CancelAuthorize => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("CancelAuthorize");

        internal static string ChooseEveryTime => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("ChooseEveryTime");

        internal static string ClearAuthorizationFinish => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("ClearAuthorizationFinish");

        internal static string ClearCacheFinish => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("ClearCacheFinish");

        internal static string LoadImageFailed => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("LoadImageFailed");

        internal static string PictureLibrary => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("PictureLibrary");

        internal static string RefreshSuccess => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("RefreshSuccess");

        internal static string SavedPictures => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("SavedPictures");

        internal static string SaveSuccess => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("SaveSuccess");

        internal static string SetFailed => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("SetFailed");

        internal static string SetSuccess => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("SetSuccess");

        internal static string ShareSuccess => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("ShareSuccess");

        internal static string WallpaperSizeFallbackNotice => ResourceLoader.GetForCurrentView(ConstantsReswName).GetString("WallpaperSizeFallbackNotice");
    }
}