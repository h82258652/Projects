using System;
using SoftwareKobo.Controls.Extensions;
using Windows.ApplicationModel;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.Controls
{
    public class ImageBrushEx : XamlCompositionBrushBase
    {
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(nameof(ImageSource), typeof(string), typeof(ImageBrushEx), new PropertyMetadata(default(string), OnImageSourceChanged));

        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(nameof(Stretch), typeof(Stretch), typeof(ImageBrushEx), new PropertyMetadata(Stretch.Uniform, OnStretchChanged));

        public event ImageFailedEventHandler ImageFailed;

        public event EventHandler ImageOpened;

        public string ImageSource
        {
            get
            {
                return (string)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        public Stretch Stretch
        {
            get
            {
                return (Stretch)GetValue(StretchProperty);
            }
            set
            {
                SetValue(StretchProperty, value);
            }
        }

        protected override void OnConnected()
        {
            base.OnConnected();

            SetImageSource(ImageSource);
        }

        protected override void OnDisconnected()
        {
            base.OnDisconnected();

            DisposeCompositionBrush();
        }

        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (ImageBrushEx)d;
            var value = (string)e.NewValue;

            obj.SetImageSource(value);
        }

        private static void OnStretchChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (ImageBrushEx)d;
            var value = (Stretch)e.NewValue;

            if (!Enum.IsDefined(typeof(Stretch), value))
            {
                throw new ArgumentOutOfRangeException(nameof(Stretch));
            }

            if (obj.CompositionBrush is CompositionSurfaceBrush brush)
            {
                brush.Stretch = (CompositionStretch)value;
            }
        }

        private void DisposeCompositionBrush()
        {
            if (CompositionBrush != null)
            {
                CompositionBrush.Dispose();
                CompositionBrush = null;
            }
        }

        private async void SetImageSource(string imageSource)
        {
            var compositor = Window.Current.Compositor;

            // 设计模式下直接显示。
            if (DesignMode.DesignModeEnabled)
            {
                if (imageSource == null)
                {
                    DisposeCompositionBrush();
                }
                else
                {
                    var imageSurface = LoadedImageSurface.StartLoadFromUri(new Uri(imageSource, UriKind.RelativeOrAbsolute));
                    var args = await imageSurface.WaitForLoadCompletedAsync();
                    DisposeCompositionBrush();
                    if (args.Status == LoadedImageSourceLoadStatus.Success)
                    {
                        var brush = compositor.CreateSurfaceBrush(imageSurface);
                        brush.Stretch = (CompositionStretch)Stretch;
                        CompositionBrush = brush;
                    }
                }
            }
            else
            {
                if (imageSource == null)
                {
                    CompositionBrush = null;
                }
                else
                {
                    var loader = ImageExSettings.Loader();
                    var result = await loader.GetImageSurfaceAsync(imageSource);
                    if (imageSource == ImageSource)// 确保在执行异步操作过程中，ImageSource 没有变动。
                    {
                        switch (result.Status)
                        {
                            case LoadedImageSourceLoadStatus.Success:
                                DisposeCompositionBrush();
                                var brush = compositor.CreateSurfaceBrush(result.Value);
                                brush.Stretch = (CompositionStretch)Stretch;
                                CompositionBrush = brush;
                                ImageOpened?.Invoke(this, EventArgs.Empty);
                                break;

                            case LoadedImageSourceLoadStatus.NetworkError:
                            case LoadedImageSourceLoadStatus.InvalidFormat:
                            case LoadedImageSourceLoadStatus.Other:
                                DisposeCompositionBrush();
                                ImageFailed?.Invoke(this, new ImageFailedEventArgs(imageSource, new ImageSurfaceFailedStatusException(result.Status)));
                                break;

                            default:
                                throw new ArgumentOutOfRangeException(nameof(result.Status));
                        }
                    }
                }
            }
        }
    }
}