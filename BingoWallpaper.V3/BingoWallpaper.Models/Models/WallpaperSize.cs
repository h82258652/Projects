using System;

namespace BingoWallpaper.Models
{
    public struct WallpaperSize : IEquatable<WallpaperSize>
    {
        public WallpaperSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Height
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public static bool operator !=(WallpaperSize size1, WallpaperSize size2)
        {
            return !(size1 == size2);
        }

        public static bool operator ==(WallpaperSize size1, WallpaperSize size2)
        {
            return size1.Width == size2.Width && size1.Height == size2.Height;
        }

        public bool Equals(WallpaperSize other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return obj is WallpaperSize size && Equals(size);
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
}