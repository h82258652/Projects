using System;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Microsoft.Graphics.Canvas.Effects;

namespace VGtime.Uwp.Brushes
{
    public class AcrylicBrush : XamlCompositionBrushBase
    {
        public static readonly DependencyProperty BackgroundSourceProperty = DependencyProperty.Register(nameof(BackgroundSource), typeof(AcrylicBackgroundSource), typeof(AcrylicBrush), new PropertyMetadata(default(AcrylicBackgroundSource), OnBackgroundSourceChanged));

        public static readonly DependencyProperty FallbackForcedProperty = DependencyProperty.Register(nameof(FallbackForced), typeof(bool), typeof(AcrylicBrush), new PropertyMetadata(default(bool), OnFallbackForcedChanged));

        public static readonly DependencyProperty TintColorProperty = DependencyProperty.Register(nameof(TintColor), typeof(Color), typeof(AcrylicBrush), new PropertyMetadata(default(Color), OnTintColorChanged));

        public static readonly DependencyProperty TintOpacityProperty = DependencyProperty.Register(nameof(TintOpacity), typeof(double), typeof(AcrylicBrush), new PropertyMetadata(1d, OnTintOpacityChanged));

        public AcrylicBackgroundSource BackgroundSource
        {
            get
            {
                return (AcrylicBackgroundSource)GetValue(BackgroundSourceProperty);
            }
            set
            {
                SetValue(BackgroundSourceProperty, value);
            }
        }

        public bool FallbackForced
        {
            get
            {
                return (bool)GetValue(FallbackForcedProperty);
            }
            set
            {
                SetValue(FallbackForcedProperty, value);
            }
        }

        public Color TintColor
        {
            get
            {
                return (Color)GetValue(TintColorProperty);
            }
            set
            {
                SetValue(TintColorProperty, value);
            }
        }

        public double TintOpacity
        {
            get
            {
                return (double)GetValue(TintOpacityProperty);
            }
            set
            {
                SetValue(TintOpacityProperty, value);
            }
        }

        protected override void OnConnected()
        {
            base.OnConnected();

            UpdateBrush();
        }

        protected override void OnDisconnected()
        {
            base.OnDisconnected();

            DisposeCompositionBrush();
        }

        private static void OnBackgroundSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (AcrylicBrush)d;
            var value = (AcrylicBackgroundSource)e.NewValue;

            if (!Enum.IsDefined(typeof(AcrylicBackgroundSource), value))
            {
                throw new ArgumentOutOfRangeException(nameof(BackgroundSource));
            }

            obj.UpdateBrush();
        }

        private static void OnFallbackForcedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (AcrylicBrush)d;

            obj.UpdateBrush();
        }

        private static void OnTintColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (AcrylicBrush)d;

            obj.UpdateBrush();
        }

        private static void OnTintOpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (AcrylicBrush)d;

            obj.UpdateBrush();
        }

        private void DisposeCompositionBrush()
        {
            if (CompositionBrush != null)
            {
                CompositionBrush.Dispose();
                CompositionBrush = null;
            }
        }

        private void UpdateBrush()
        {
            DisposeCompositionBrush();

            var compositor = Window.Current.Compositor;

            var compositeEffect = new CompositeEffect();
            CompositionBackdropBrush backdropBrush;

            if (BackgroundSource == AcrylicBackgroundSource.Backdrop)
            {
                compositeEffect.Sources.Add(new GaussianBlurEffect()
                {
                    BlurAmount = 50,
                    BorderMode = EffectBorderMode.Hard,
                    Optimization = EffectOptimization.Speed,
                    Source = new CompositionEffectSourceParameter("Backdrop")
                });
                backdropBrush = compositor.CreateBackdropBrush();
            }
            else
            {
                compositeEffect.Sources.Add(new CompositionEffectSourceParameter("Backdrop"));
                backdropBrush = compositor.CreateHostBackdropBrush();
            }

            compositeEffect.Sources.Add(new OpacityEffect()
            {
                Opacity = (float)TintOpacity,
                Source = new ColorSourceEffect()
                {
                    Color = TintColor
                }
            });

            var effectFactory = compositor.CreateEffectFactory(compositeEffect);
            var effectBrush = effectFactory.CreateBrush();

            effectBrush.SetSourceParameter("Backdrop", backdropBrush);

            CompositionBrush = effectBrush;
        }
    }
}