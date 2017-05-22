using System;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.Controls
{
    public class ImageExBrush : XamlCompositionBrushBase
    {
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(nameof(ImageSource), typeof(string), typeof(ImageExBrush), new PropertyMetadata(default(string), OnImageSourceChanged));

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

        protected override async void OnConnected()
        {
            base.OnConnected();

            var compositor = Window.Current.Compositor;

            var r = await _loader.GetBytesAsync(ImageSource);

            var ms = new MemoryStream();

            // https://github.com/Microsoft/uwp-experiences/blob/9990c6426719b421a8a485eda00d37a80c546ac0/apps/NorthwindPhoto/NorthwindPhoto/BlurImageBrush.cs

            var surface = LoadedImageSurface.StartLoadFromStream(ms.AsRandomAccessStream());

            surface.LoadCompleted += Surface_LoadCompleted;
        }

        private void Surface_LoadCompleted(LoadedImageSurface sender, LoadedImageSourceLoadCompletedEventArgs args)
        {
            //var brush = compositor.CreateSurfaceBrush(sender);
        }

        private IImageLoader _loader;

        protected override void OnDisconnected()
        {
            base.OnDisconnected();
        }

        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}