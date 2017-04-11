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

        public static bool operator !=(WallpaperSize left, WallpaperSize right)
        {
            return !(left == right);
        }

        public static bool operator ==(WallpaperSize left, WallpaperSize right)
        {
            return left.Equals(right);
        }

        public bool Equals(WallpaperSize other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            if (obj is WallpaperSize)
            {
                return Equals((WallpaperSize)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}x{1}", Width, Height);
        }
    }
}