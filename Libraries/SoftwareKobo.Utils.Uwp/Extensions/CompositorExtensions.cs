using System;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml.Media.Animation;

namespace SoftwareKobo.Extensions
{
    public static class CompositorExtensions
    {
        public static CubicBezierEasingFunction CreateBackEasingFunction(this Compositor compositor, EasingMode easingMode)
        {
            if (compositor == null)
            {
                throw new ArgumentNullException(nameof(compositor));
            }

            switch (easingMode)
            {
                case EasingMode.EaseOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.175f, 0.885f), new Vector2(0.32f, 1.275f));

                case EasingMode.EaseIn:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.6f, -0.28f), new Vector2(0.735f, 0.045f));

                case EasingMode.EaseInOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.68f, -0.55f), new Vector2(0.265f, 1.55f));

                default:
                    throw new ArgumentOutOfRangeException(nameof(easingMode));
            }
        }

        public static CubicBezierEasingFunction CreateCircleEasingFunction(this Compositor compositor, EasingMode easingMode)
        {
            if (compositor == null)
            {
                throw new ArgumentNullException(nameof(compositor));
            }

            switch (easingMode)
            {
                case EasingMode.EaseOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.075f, 0.82f), new Vector2(0.165f, 1f));

                case EasingMode.EaseIn:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.6f, 0.04f), new Vector2(0.98f, 0.335f));

                case EasingMode.EaseInOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.785f, 0.135f), new Vector2(0.15f, 0.86f));

                default:
                    throw new ArgumentOutOfRangeException(nameof(easingMode));
            }
        }

        public static CubicBezierEasingFunction CreateCubicEasingFunction(this Compositor compositor, EasingMode easingMode)
        {
            if (compositor == null)
            {
                throw new ArgumentNullException(nameof(compositor));
            }

            switch (easingMode)
            {
                case EasingMode.EaseOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.215f, 0.61f), new Vector2(0.355f, 1f));

                case EasingMode.EaseIn:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.55f, 0.055f), new Vector2(0.675f, 0.19f));

                case EasingMode.EaseInOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.645f, 0.045f), new Vector2(0.355f, 1f));

                default:
                    throw new ArgumentOutOfRangeException(nameof(easingMode));
            }
        }

        public static CubicBezierEasingFunction CreateExponentialEasingFunction(this Compositor compositor, EasingMode easingMode)
        {
            if (compositor == null)
            {
                throw new ArgumentNullException(nameof(compositor));
            }

            switch (easingMode)
            {
                case EasingMode.EaseOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.19f, 1f), new Vector2(0.22f, 1f));

                case EasingMode.EaseIn:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.95f, 0.05f), new Vector2(0.795f, 0.035f));

                case EasingMode.EaseInOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(1f, 0f), new Vector2(0f, 1f));

                default:
                    throw new ArgumentOutOfRangeException(nameof(easingMode));
            }
        }

        public static CubicBezierEasingFunction CreateQuadraticEasingFunction(this Compositor compositor, EasingMode easingMode)
        {
            if (compositor == null)
            {
                throw new ArgumentNullException(nameof(compositor));
            }

            switch (easingMode)
            {
                case EasingMode.EaseOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.25f, 0.46f), new Vector2(0.45f, 0.94f));

                case EasingMode.EaseIn:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.55f, 0.085f), new Vector2(0.68f, 0.53f));

                case EasingMode.EaseInOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.455f, 0.03f), new Vector2(0.515f, 0.955f));

                default:
                    throw new ArgumentOutOfRangeException(nameof(easingMode));
            }
        }

        public static CubicBezierEasingFunction CreateQuarticEasingFunction(this Compositor compositor, EasingMode easingMode)
        {
            if (compositor == null)
            {
                throw new ArgumentNullException(nameof(compositor));
            }

            switch (easingMode)
            {
                case EasingMode.EaseOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.165f, 0.84f), new Vector2(0.44f, 1f));

                case EasingMode.EaseIn:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.895f, 0.03f), new Vector2(0.685f, 0.22f));

                case EasingMode.EaseInOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.77f, 0f), new Vector2(0.175f, 1f));

                default:
                    throw new ArgumentOutOfRangeException(nameof(easingMode));
            }
        }

        public static CubicBezierEasingFunction CreateQuinticEasingFunction(this Compositor compositor, EasingMode easingMode)
        {
            if (compositor == null)
            {
                throw new ArgumentNullException(nameof(compositor));
            }

            switch (easingMode)
            {
                case EasingMode.EaseOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.23f, 1f), new Vector2(0.32f, 1f));

                case EasingMode.EaseIn:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.755f, 0.05f), new Vector2(0.855f, 0.06f));

                case EasingMode.EaseInOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.86f, 0f), new Vector2(0.07f, 1f));

                default:
                    throw new ArgumentOutOfRangeException(nameof(easingMode));
            }
        }

        public static CubicBezierEasingFunction CreateSineEasingFunction(this Compositor compositor, EasingMode easingMode)
        {
            if (compositor == null)
            {
                throw new ArgumentNullException(nameof(compositor));
            }

            switch (easingMode)
            {
                case EasingMode.EaseOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.39f, 0.575f), new Vector2(0.565f, 1f));

                case EasingMode.EaseIn:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.47f, 0f), new Vector2(0.745f, 0.715f));

                case EasingMode.EaseInOut:
                    return compositor.CreateCubicBezierEasingFunction(new Vector2(0.445f, 0.05f), new Vector2(0.55f, 0.95f));

                default:
                    throw new ArgumentOutOfRangeException(nameof(easingMode));
            }
        }
    }
}