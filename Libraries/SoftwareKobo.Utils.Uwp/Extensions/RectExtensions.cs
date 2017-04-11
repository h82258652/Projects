using Windows.Foundation;

namespace SoftwareKobo.Extensions
{
    public static class RectExtensions
    {
        public static bool IntersectsWith(this Rect rect1, Rect rect2)
        {
            if (rect1.IsEmpty || rect2.IsEmpty)
            {
                return false;
            }

            return rect1.Left <= rect2.Right
                   && rect1.Right >= rect2.Left
                   && rect1.Top <= rect2.Bottom
                   && rect1.Bottom >= rect2.Top;
        }
    }
}