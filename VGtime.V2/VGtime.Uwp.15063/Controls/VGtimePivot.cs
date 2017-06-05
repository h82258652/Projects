using System;
using System.Linq;
using SoftwareKobo.Extensions;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Controls
{
    [TemplatePart(Name = StaticHeaderTemplateName, Type = typeof(PivotHeaderPanel))]
    [TemplatePart(Name = HeaderTemplateName, Type = typeof(PivotHeaderPanel))]
    [TemplatePart(Name = SelectedHeaderIndicatorTemplateName, Type = typeof(Rectangle))]
    public sealed class VGtimePivot : Pivot
    {
        private const string HeaderTemplateName = "Header";

        private const string SelectedHeaderIndicatorTemplateName = "PART_SelectedHeaderIndicator";

        private const string StaticHeaderTemplateName = "StaticHeader";

        private PivotHeaderPanel _header;

        private bool _isInHackFix;

        private Visual _selectedHeaderIndicatorVisual;

        private PivotHeaderPanel _staticHeader;

        public VGtimePivot()
        {
            DefaultStyleKey = typeof(VGtimePivot);

            Loaded += VGtimePivot_Loaded;
            SelectionChanged += VGtimePivot_SelectionChanged;
            SizeChanged += VGtimePivot_SizeChanged;
        }

        public event VGtimePivotSelectedHeaderItemClickEventHandler SelectedHeaderItemClick;

        internal void FireSelectedHeaderItemClick(PivotHeaderItem item)
        {
            SelectedHeaderItemClick?.Invoke(this, new VGtimePivotSelectedHeaderItemClickEventArgs(item));
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _staticHeader = (PivotHeaderPanel)GetTemplateChild(StaticHeaderTemplateName);
            _header = (PivotHeaderPanel)GetTemplateChild(HeaderTemplateName);

            var selectedHeaderIndicator = (Rectangle)GetTemplateChild(SelectedHeaderIndicatorTemplateName);
            _selectedHeaderIndicatorVisual = ElementCompositionPreview.GetElementVisual(selectedHeaderIndicator);
            var scale = _selectedHeaderIndicatorVisual.Scale;
            scale.X = 0;
            _selectedHeaderIndicatorVisual.Scale = scale;
        }

        private void UpdateSelectedHeaderIndicator(bool useAnimation = true)
        {
            if (_header != null)
            {
                var selectedIndex = SelectedIndex;
                if (selectedIndex >= 0)
                {
                    var pivotItem = (PivotItem)ContainerFromIndex(selectedIndex);
                    if (pivotItem != null)
                    {
                        if (_staticHeader.Children.Count > 0)
                        {
                            var pivotHeaderItem = _staticHeader.Children.OfType<PivotHeaderItem>().FirstOrDefault(temp => temp == pivotItem.Header || Equals(temp.Content, pivotItem.Header));
                            if (pivotHeaderItem != null)
                            {
                                var offsetX = (float)(Canvas.GetLeft(pivotHeaderItem) + pivotHeaderItem.Padding.Left);
                                var scaleX = (float)(pivotHeaderItem.ActualWidth - pivotHeaderItem.Padding.Left - pivotHeaderItem.Padding.Right);

                                if (_selectedHeaderIndicatorVisual.Scale.X > 0 && useAnimation)
                                {
                                    var compositor = _selectedHeaderIndicatorVisual.Compositor;

                                    var offsetAnimation = compositor.CreateScalarKeyFrameAnimation();
                                    offsetAnimation.InsertKeyFrame(1, offsetX, compositor.CreateCubicEasingFunction(EasingMode.EaseInOut));
                                    offsetAnimation.Duration = TimeSpan.FromSeconds(0.3);

                                    var scaleAnimation = compositor.CreateScalarKeyFrameAnimation();
                                    scaleAnimation.InsertKeyFrame(1, scaleX, compositor.CreateCubicEasingFunction(EasingMode.EaseInOut));
                                    scaleAnimation.Duration = TimeSpan.FromSeconds(0.3);

                                    _selectedHeaderIndicatorVisual.StartAnimation("Offset.X", offsetAnimation);
                                    _selectedHeaderIndicatorVisual.StartAnimation("Scale.X", scaleAnimation);
                                }
                                else
                                {
                                    var offset = _selectedHeaderIndicatorVisual.Offset;
                                    offset.X = offsetX;
                                    _selectedHeaderIndicatorVisual.Offset = offset;

                                    var scale = _selectedHeaderIndicatorVisual.Scale;
                                    scale.X = scaleX;
                                    _selectedHeaderIndicatorVisual.Scale = scale;
                                }
                            }
                        }
                        else if (_header.Children.Count > 0)
                        {
                            var pivotHeaderItem = _header.Children.OfType<PivotHeaderItem>().FirstOrDefault(temp => temp == pivotItem.Header || Equals(temp.Content, pivotItem.Header));
                            if (pivotHeaderItem != null)
                            {
                                var offsetX = (float)pivotHeaderItem.Padding.Left;
                                var scaleX = (float)(pivotHeaderItem.ActualWidth - pivotHeaderItem.Padding.Left - pivotHeaderItem.Padding.Right);

                                if (_selectedHeaderIndicatorVisual.Scale.X > 0 && useAnimation)
                                {
                                    var compositor = _selectedHeaderIndicatorVisual.Compositor;

                                    var offsetAnimation = compositor.CreateScalarKeyFrameAnimation();
                                    offsetAnimation.InsertKeyFrame(1, offsetX, compositor.CreateCubicEasingFunction(EasingMode.EaseInOut));
                                    offsetAnimation.Duration = TimeSpan.FromSeconds(0.3);

                                    var scaleAnimation = compositor.CreateScalarKeyFrameAnimation();
                                    scaleAnimation.InsertKeyFrame(1, scaleX, compositor.CreateCubicEasingFunction(EasingMode.EaseInOut));
                                    scaleAnimation.Duration = TimeSpan.FromSeconds(0.3);

                                    _selectedHeaderIndicatorVisual.StartAnimation("Offset.X", offsetAnimation);
                                    _selectedHeaderIndicatorVisual.StartAnimation("Scale.X", scaleAnimation);
                                }
                                else
                                {
                                    var offset = _selectedHeaderIndicatorVisual.Offset;
                                    offset.X = offsetX;
                                    _selectedHeaderIndicatorVisual.Offset = offset;

                                    var scale = _selectedHeaderIndicatorVisual.Scale;
                                    scale.X = scaleX;
                                    _selectedHeaderIndicatorVisual.Scale = scale;
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void VGtimePivot_Loaded(object sender, RoutedEventArgs e)
        {
            // Hack fix.
            _isInHackFix = true;
            var width = Width;
            Width = ActualWidth + 1;
            await this.WaitForLayoutUpdateAsync();
            Width = width;
            _isInHackFix = false;
        }

        private void VGtimePivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedHeaderIndicator();
        }

        private void VGtimePivot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!_isInHackFix)
            {
                UpdateSelectedHeaderIndicator(false);
            }
        }
    }
}