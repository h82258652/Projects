using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Uwp.Messages;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Controls
{
    public sealed partial class ChooseShareDialog : IDialog
    {
        private readonly Compositor _compositor;

        private readonly InsetClip _contentGridVisualClip;

        public ChooseShareDialog()
        {
            InitializeComponent();

            var contentGridVisual = ElementCompositionPreview.GetElementVisual(ContentGrid);
            _compositor = contentGridVisual.Compositor;
            _compositor = contentGridVisual.Compositor;
            _contentGridVisualClip = _compositor.CreateInsetClip(0, 80, 0, 80);
            contentGridVisual.Clip = _contentGridVisualClip;
        }

        public async void Hide()
        {
            await HideAsync();
        }

        public async Task HideAsync()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            Storyboard.SetTarget(animation, BackgroundGrid);
            Storyboard.SetTargetProperty(animation, "Opacity");
            storyboard.Children.Add(animation);

            var tcs = new TaskCompletionSource<object>();
            var batch = _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
            TypedEventHandler<object, CompositionBatchCompletedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                batch.Completed -= handler;
                tcs.SetResult(null);
            };
            batch.Completed += handler;

            var topInsetAnimation = _compositor.CreateScalarKeyFrameAnimation();
            topInsetAnimation.InsertKeyFrame(0, 0);
            topInsetAnimation.InsertKeyFrame(1, 80);
            topInsetAnimation.Duration = TimeSpan.FromSeconds(0.3);
            _contentGridVisualClip.StartAnimation("TopInset", topInsetAnimation);

            var bottomInsetAnimation = _compositor.CreateScalarKeyFrameAnimation();
            bottomInsetAnimation.InsertKeyFrame(0, 0);
            bottomInsetAnimation.InsertKeyFrame(1, 80);
            bottomInsetAnimation.Duration = TimeSpan.FromSeconds(0.3);
            _contentGridVisualClip.StartAnimation("BottomInset", bottomInsetAnimation);

            batch.End();

            await Task.WhenAll(storyboard.BeginAsync(), tcs.Task);
        }

        public async void Show()
        {
            await ShowAsync();
        }

        public async Task ShowAsync()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            Storyboard.SetTarget(animation, BackgroundGrid);
            Storyboard.SetTargetProperty(animation, "Opacity");
            storyboard.Children.Add(animation);

            var tcs = new TaskCompletionSource<object>();
            var batch = _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
            TypedEventHandler<object, CompositionBatchCompletedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                batch.Completed -= handler;
                tcs.SetResult(null);
            };
            batch.Completed += handler;

            var topInsetAnimation = _compositor.CreateScalarKeyFrameAnimation();
            topInsetAnimation.InsertKeyFrame(0, 80);
            topInsetAnimation.InsertKeyFrame(1, 0);
            topInsetAnimation.Duration = TimeSpan.FromSeconds(0.3);
            _contentGridVisualClip.StartAnimation("TopInset", topInsetAnimation);

            var bottomInsetAnimation = _compositor.CreateScalarKeyFrameAnimation();
            bottomInsetAnimation.InsertKeyFrame(0, 80);
            bottomInsetAnimation.InsertKeyFrame(1, 0);
            bottomInsetAnimation.Duration = TimeSpan.FromSeconds(0.3);
            _contentGridVisualClip.StartAnimation("BottomInset", bottomInsetAnimation);

            batch.End();

            await Task.WhenAll(storyboard.BeginAsync(), tcs.Task);
        }

        private void BackgroundGrid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
            Messenger.Default.Send(new HideChooseShareDialogMessage());
        }

        private void SinaWeiboShareButton_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send(new SinaWeiboShareSelectedMessage());
            Messenger.Default.Send(new HideChooseShareDialogMessage());
        }

        private void SystemShareButton_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send(new SystemShareSelectedMessage());
            Messenger.Default.Send(new HideChooseShareDialogMessage());
        }
    }
}