﻿namespace BingoWallpaper
{
    public delegate void TypedEventHandler<in TSender, in TResult>(TSender sender, TResult args);
}