using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using BingoWallpaper.Extensions;

namespace BingoWallpaper.Animation
{
    public sealed class ConnectedAnimation
    {
        /// <summary>
        /// 动画承载 Canvas 名称
        /// </summary>
        private const string ConnectedAnimationHostCanvasName = "ConnectedAnimationHostCanvas";

        private readonly ConnectedAnimationService _ownerAnimationService;

        private readonly UIElement _source;

        private Canvas _connectedAnimationHostCanvas;

        private UIElement _destination;

        private Image _destinationMirror;

        private Visibility _destinationVisibility;

        private Image _sourceMirror;

        private Visibility _sourceVisibility;

        private Storyboard _storyboard;

        internal ConnectedAnimation(ConnectedAnimationService ownerAnimationService, UIElement source)
        {
            _ownerAnimationService = ownerAnimationService;
            _source = source;
        }

        public event TypedEventHandler<ConnectedAnimation, object> Completed;

        internal bool IsAvailable
        {
            get;
            set;
        } = true;

        public void Cancel()
        {
            if (_storyboard != null)
            {
                _storyboard.Stop();
                Cleanup();
            }

            IsAvailable = false;
        }

        public bool TryStart(UIElement destination)
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (ReferenceEquals(_source, destination))
            {
                return false;
            }
            if (!IsAvailable)
            {
                Cancel();
                return false;
            }

            var sourceConnectedAnimationHostCanvas = GetConnectedAnimationHostCanvas(_source);
            var destinationConnectedAnimationHostCanvas = GetConnectedAnimationHostCanvas(destination);
            if (!ReferenceEquals(sourceConnectedAnimationHostCanvas, destinationConnectedAnimationHostCanvas))
            {
                throw new InvalidOperationException("起始元素和目标元素不在同一个窗口！");
            }
            _destination = destination;
            _connectedAnimationHostCanvas = sourceConnectedAnimationHostCanvas;

            GetElementSize(_source, out var sourceWidth, out var sourceHeight);
            GetElementSize(destination, out var destinationWidth, out var destinationHeight);

            _sourceMirror = new Image()
            {
                Source = RenderVisual(_source, sourceWidth, sourceHeight),
                Stretch = Stretch.None,
                RenderTransform = new TransformGroup()
                {
                    Children = new TransformCollection()
                    {
                        new ScaleTransform(),
                        new TranslateTransform()
                    }
                }
            };
            _destinationMirror = new Image()
            {
                Source = RenderVisual(destination, destinationWidth, destinationHeight),
                Stretch = Stretch.None,
                RenderTransform = new TransformGroup()
                {
                    Children = new TransformCollection()
                    {
                        new ScaleTransform(),
                        new TranslateTransform()
                    }
                }
            };

            var sourcePosition = _source.TranslatePoint(new Point(), _connectedAnimationHostCanvas);
            var destinationPosition = destination.TranslatePoint(new Point(), _connectedAnimationHostCanvas);

            var duration = _ownerAnimationService.DefaultDuration;
            var easingFunction = _ownerAnimationService.DefaultEasingFunction;

            _storyboard = new Storyboard();

            var sourceOffsetXAnimation = new DoubleAnimation()
            {
                From = sourcePosition.X,
                To = destinationPosition.X,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(sourceOffsetXAnimation, _sourceMirror);
            Storyboard.SetTargetProperty(sourceOffsetXAnimation, new PropertyPath(
                "(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)"));
            _storyboard.Children.Add(sourceOffsetXAnimation);

            var sourceOffsetYAnimation = new DoubleAnimation()
            {
                From = sourcePosition.Y,
                To = destinationPosition.Y,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(sourceOffsetYAnimation, _sourceMirror);
            Storyboard.SetTargetProperty(sourceOffsetYAnimation, new PropertyPath(
                "(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)"));
            _storyboard.Children.Add(sourceOffsetYAnimation);

            var sourceScaleXAnimation = new DoubleAnimation()
            {
                From = 1,
                To = destinationWidth / sourceWidth,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(sourceScaleXAnimation, _sourceMirror);
            Storyboard.SetTargetProperty(sourceScaleXAnimation, new PropertyPath(
                "(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"));
            _storyboard.Children.Add(sourceScaleXAnimation);

            var sourceScaleYAnimation = new DoubleAnimation()
            {
                From = 1,
                To = destinationHeight / sourceHeight,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(sourceScaleYAnimation, _sourceMirror);
            Storyboard.SetTargetProperty(sourceScaleYAnimation, new PropertyPath(
                "(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));
            _storyboard.Children.Add(sourceScaleYAnimation);

            var sourceOpacityAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(sourceOpacityAnimation, _sourceMirror);
            Storyboard.SetTargetProperty(sourceOpacityAnimation, new PropertyPath("Opacity"));
            _storyboard.Children.Add(sourceOpacityAnimation);

            var destinationOffsetXAnimation = new DoubleAnimation()
            {
                From = sourcePosition.X,
                To = destinationPosition.X,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(destinationOffsetXAnimation, _destinationMirror);
            Storyboard.SetTargetProperty(destinationOffsetXAnimation, new PropertyPath(
                "(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)"));
            _storyboard.Children.Add(destinationOffsetXAnimation);

            var destinationOffsetYAnimation = new DoubleAnimation()
            {
                From = sourcePosition.Y,
                To = destinationPosition.Y,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(destinationOffsetYAnimation, _destinationMirror);
            Storyboard.SetTargetProperty(destinationOffsetYAnimation, new PropertyPath(
                "(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)"));
            _storyboard.Children.Add(destinationOffsetYAnimation);

            var destinationScaleXAnimation = new DoubleAnimation()
            {
                From = sourceWidth / destinationWidth,
                To = 1,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(destinationScaleXAnimation, _destinationMirror);
            Storyboard.SetTargetProperty(destinationScaleXAnimation, new PropertyPath(
                "(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"));
            _storyboard.Children.Add(destinationScaleXAnimation);

            var destinationScaleYAnimation = new DoubleAnimation()
            {
                From = sourceHeight / destinationHeight,
                To = 1,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(destinationScaleYAnimation, _destinationMirror);
            Storyboard.SetTargetProperty(destinationScaleYAnimation, new PropertyPath(
                "(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));
            _storyboard.Children.Add(destinationScaleYAnimation);

            var destinationOpacityAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = duration,
                EasingFunction = easingFunction
            };
            Storyboard.SetTarget(destinationOpacityAnimation, _destinationMirror);
            Storyboard.SetTargetProperty(destinationOpacityAnimation, new PropertyPath("Opacity"));
            _storyboard.Children.Add(destinationOpacityAnimation);

            _sourceVisibility = _source.Visibility;
            _destinationVisibility = destination.Visibility;
            void StoryboardCompleted(object sender, EventArgs e)
            {
                _storyboard.Completed -= StoryboardCompleted;

                Cleanup();

                Completed?.Invoke(this, null);
            }
            _storyboard.Completed += StoryboardCompleted;

            _connectedAnimationHostCanvas.Children.Add(_sourceMirror);
            _connectedAnimationHostCanvas.Children.Add(_destinationMirror);
            _source.Visibility = Visibility.Hidden;
            destination.Visibility = Visibility.Hidden;

            _storyboard.Begin();

            IsAvailable = false;

            return true;
        }

        private static Canvas GetConnectedAnimationHostCanvas(UIElement element)
        {
            var connectedAnimationHostCanvas = Window.GetWindow(element).GetDescendantsOfType<Canvas>().FirstOrDefault(temp => temp.Name == ConnectedAnimationHostCanvasName);
            if (connectedAnimationHostCanvas == null)
            {
                throw new InvalidOperationException($"查找 {ConnectedAnimationHostCanvasName} 失败！");
            }
            return connectedAnimationHostCanvas;
        }

        private static void GetElementSize(UIElement element, out double width, out double height)
        {
            if (element is FrameworkElement frameworkElement)
            {
                width = frameworkElement.ActualWidth;
                height = frameworkElement.ActualHeight;
            }
            else
            {
                var renderSize = element.RenderSize;
                width = renderSize.Width;
                height = renderSize.Height;
            }
        }

        private static ImageSource RenderVisual(Visual visual, double width, double height)
        {
            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
            {
                var visualBrush = new VisualBrush(visual);
                drawingContext.DrawRectangle(visualBrush, null, new Rect(0, 0, width, height));
                drawingContext.Close();
            }

            var bitmapWidth = (int)Math.Ceiling(width);
            var bitmapHeight = (int)Math.Ceiling(height);
            using (var graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
            {
                var renderTargetBitmap = new RenderTargetBitmap(bitmapWidth, bitmapHeight, graphics.DpiX, graphics.DpiY, PixelFormats.Default);
                renderTargetBitmap.Render(drawingVisual);
                renderTargetBitmap.Freeze();
                return renderTargetBitmap;
            }
        }

        private void Cleanup()
        {
            if (_destination != null
                && _connectedAnimationHostCanvas != null
                && _sourceMirror != null
                && _destinationMirror != null)
            {
                _source.Visibility = _sourceVisibility;
                _destination.Visibility = _destinationVisibility;
                _connectedAnimationHostCanvas.Children.Remove(_sourceMirror);
                _connectedAnimationHostCanvas.Children.Remove(_destinationMirror);

                _storyboard = null;
            }
        }
    }
}