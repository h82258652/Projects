using System.Windows;
using System.Windows.Media.Animation;

namespace BingoWallpaper.Animation
{
    public sealed class CubicBezierEase : IEasingFunction
    {
        public Point ControlPoint1
        {
            get;
            set;
        }

        public Point ControlPoint2
        {
            get;
            set;
        }

        public double Ease(double normalizedTime)
        {
            return 3 * ControlPoint1.Y * normalizedTime * (1 - normalizedTime) * (1 - normalizedTime) + 3 * ControlPoint2.Y * normalizedTime * normalizedTime * (1 - normalizedTime) + normalizedTime * normalizedTime * normalizedTime;
        }
    }
}